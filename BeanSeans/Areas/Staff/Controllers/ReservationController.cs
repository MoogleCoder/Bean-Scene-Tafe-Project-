using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanSeans.Data;
using BeanSeans.Areas.Administration;
using Microsoft.AspNetCore.Identity;
using BeanSeans.Areas.Staff.Models.Reservation;
using BeanSeans.Models.Reservation;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Authorization;

namespace BeanSeans.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class ReservationController : AdministrationAreaController
    {

        public ReservationController(SignInManager<IdentityUser> sim, UserManager<IdentityUser> um, ApplicationDbContext _db) : base(sim, um, _db)
        {

        }


        [HttpGet]
        public async Task<IActionResult> TablesIndex()
        {
            var reservationTables = await _db.TableReservations
                                                              .Include(tr => tr.Reservation)
                                                              .Include(t => t.Table)
                                                              .OrderBy(r => r.Reservation.StartTime)
                                                              .OrderBy(t => t.Table)
                                                              .ToListAsync();


            return View();

        }

        [HttpGet]
        //id == reservation id
        //manager will choose tables to add reservations
        public async Task<IActionResult> Tables(int id)
        {
            //get all tables and area
            var tables = await _db.Tables.Include(t => t.Area).OrderBy(t => t.Area.Name).ThenBy(t => t.Name).ToListAsync();
            //get reservations
            //include if res has table setting
            var reservation = await _db.Reservations
                                       .Include(r => r.TableReservations)//get assigened reserTables
                                           .ThenInclude(tr => tr.Table)
                                        .FirstOrDefaultAsync(r => r.Id == id);//reservation id

            //set the reservation to the Creating Table
            var m = new Models.Area.Tables { Reservation = reservation };
            //just assigned to reserva
            //now we e
            //table is from DB

            //do 30 times for 30 tables.
            foreach (var t in tables)
            {
                var tableDetail = new Models.Area.TableDetails
                {
                    TableId = t.Id,
                    TableName = t.Name,
                    AreaName = t.Area.Name,
                    //if there is any tables set before==>true
                    Selected = reservation.TableReservations.Any(rt => rt.TableId == t.Id)
                };
                m.TableDetails.Add(tableDetail);
            }

            //logic
            var reservationTables = await _db.TableReservations.ToArrayAsync();

            List<int> IdOfReservationWithLaterEndTime = new List<int>();

            //get all the tables that has reservations
            foreach (var rt in reservationTables)
            {
                //reservation that has table already
                var reser = await _db.Reservations.FirstOrDefaultAsync(r => r.Id == rt.ReservationId);

                if (reser.EndTime > reservation.StartTime)//if the tables has reservation and their end time is later
                                                          //than what user choose, then the table shouldn't be able to the user to select.
                                                          //erase from the array.
                {
                    var deleted = m.TableDetails.FirstOrDefault(m => m.TableId == rt.TableId);

                    m.TableDetails.Remove(deleted);
                }
            }




            return View(m);
        }

        [HttpPost]
        //id == reservation id
        //manager will choose tables to add reservations
        public async Task<IActionResult> Tables(Models.Area.Tables m)
        {
            try
            {
                int id = m.Reservation.Id;

                //clear the previous selected tables from the res
                var reservation = await _db.Reservations
                                          .Include(r => r.TableReservations)
                                          .ThenInclude(tr => tr.Table)
                                          .FirstOrDefaultAsync(r => r.Id == id);
                //first remove all existing tables assigned to the reservation
                reservation.TableReservations.Clear();
                await _db.SaveChangesAsync();

                var endTime = reservation.EndTime;//get end time


                //add the selected tables to db
                var selectedTables = m.TableDetails.Where(to => to.Selected);


                foreach (var st in selectedTables)
                {


                    //set the selected table to the tableReservations-connection table
                    var tr = new TableReservation { TableId = st.TableId };
                    //add the connection table to reservation
                    reservation.TableReservations.Add(tr);
                }

                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Reservation", new { Area = "Staff" });
            }
            catch (Exception)
            {
                return View(m);
            }

        }



        //we have to have sittings to make reserv
        //when we add reservation, first we add siting
        //model: Sitting, List Tep
        public async Task<IActionResult> Sittings()
        {




            var sittings = await _db.Sittings
                              .Include(s => s.SittingType)
                                       .OrderBy(s => s.Start)
                                       .Where(s => s.Start >= DateTime.Now)
                                       .ToListAsync();
            return View(sittings);
        }
        //after sitting, user will be navigated to tables to choose area and table

        //create reservation after choose sitting.
        //manager has to choose member 
        //id==sitting Id
        [HttpGet]

        public async Task<IActionResult> CreateMemberReservation(int id)
        {

            var sitting = await _db.Sittings
                                   .Include(s => s.SittingType)
                                   .FirstOrDefaultAsync(s => s.Id == id);
            if (sitting == null)
            {
                return NotFound();
            }
            

            var members = _db.Members.Select(me => new
            {
                Id = me.Id,
                Name = $"{me.LastName}, {me.FirstName}"
            }).ToList();

            var m = new CreateMemberReservation
            {


                StartTime = sitting.Start,

                SittingId = sitting.Id,
                Sitting = $"{sitting.SittingType.Name} {sitting.Start}",
                //StatusId = 1, //initial status is pending with id of 1
                //  StatusOptions = new SelectList(_db.ReservationStatuses.ToList(), "Id", "Name"),
                SourceOptions = new SelectList(_db.ReservationSources.ToList(), "Id", "Name"),
                MemberOptions = new SelectList(members, "Id", "Name")
            };



            return View(m);
        }


        //once manager chooses member to add reservation
        //it will show the reservation form
        //Id is member ID
        [HttpPost]
        public async Task<IActionResult> CreateMemberReservation(CreateMemberReservation m)
        {
            //get sitting from m
            var sitting = await _db.Sittings
                .Include(s => s.Reservations)
                .FirstOrDefaultAsync(s => s.Id == m.SittingId);

            if (sitting == null) { return NotFound(); }
            if (m.StartTime < sitting.Start || m.StartTime > sitting.End || m.StartTime.AddMinutes(m.Duration) > sitting.End)
            {
                ModelState.AddModelError("StartTime", "Invalid Time, must fall within sitting start/end times");
            }
            if (m.Guest > sitting.GuestAvailabilityCount || m.Guest <= 0)
            {
                ModelState.AddModelError("Guest", "Invalid Guest Number");
            }

            //if model state is valid create new reservation and redirect to confirmation page
            if (ModelState.IsValid)
            {
                var member = await _db.Members.FirstOrDefaultAsync(me => me.Id == m.MemberId);
                var r = new Reservation
                {
                    Guest = m.Guest,
                    Duration = m.Duration,
                    Note = m.Note,
                    SourceId = m.SourceId,
                    StartTime = m.StartTime,
                    StatusId = 1,
                    SittingId = sitting.Id
                };
                //connect reservation and person
                member.Reservations.Add(r);
                //save cahnge
                _db.SaveChanges();
                return RedirectToAction(nameof(Confirmation), new { id = r.Id });
            }

            //otherwise re instantiate select lists for members and source options
            m.SourceOptions = new SelectList(_db.ReservationSources.ToList(), "Id", "Name");
            m.MemberOptions = new SelectList(_db.Members.Select(me => new { Id = me.Id, Name = $"{me.LastName}, {me.FirstName}" }).ToList(), "Id", "Name");
            //pass model to view and send back to client 
            return View(m);

        }

        public async Task<IActionResult> Confirmation(int id)
        {

            var reservation = await _db.Reservations
                .Include(r => r.Person)
                .Include(r => r.Sitting)
                   .ThenInclude(s => s.SittingType)
                .Include(r => r.Source)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Staff/Reservation
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var reservations = await _db.Reservations
                                        .Include(r => r.Person)
                                        .Include(r => r.Sitting)
                                        .ThenInclude(st => st.SittingType)
                                        .Include(r => r.Source)
                                        .Include(r => r.Status)
                                        .Include(r => r.TableReservations)
                                        .ThenInclude(tr => tr.Table)
                                        .OrderBy(r => r.StartTime)
                                        .Where(r => r.Status.Id !=3)
                                        .Where(r => r.Status.Id != 5)

                                        .ToListAsync();

            return View(reservations);
        }

        // GET: Staff/Reservation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _db.Reservations
                .Include(r => r.Person)
                .Include(r => r.Sitting)
                .ThenInclude(s=>s.SittingType)
                .Include(r => r.Source)
                .Include(r => r.Status)
                .Include(r=>r.TableReservations)
                .ThenInclude(tr=>tr.Table)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        //id==reservation id
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            var reservation = await _db.Reservations
                                                  .Include(r => r.Person)
                                                   .FirstOrDefaultAsync(r=>r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
           var status = await _db.ReservationStatuses.ToListAsync();
            ViewBag.Status = new SelectList(status, "Id", "Name");
            return View(reservation);
        }

        // POST: Staff/Reservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //id == reservation id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reservation reservation)
        {

            var re = await _db.Reservations
                                          .Include(r=>r.Person)
                                          .Include(r=>r.Sitting)
                                          .ThenInclude(r=>r.SittingType)
                                          .Include(r=>r.Status)
                                          .FirstOrDefaultAsync(r=>r.Id==id);
            if (re == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    re.Guest = reservation.Guest;
                    re.Note = reservation.Note;
                    re.StatusId = reservation.StatusId;
                    re.Duration = reservation.Duration;
                    _db.Update(re);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            //fail

            var status = await _db.ReservationStatuses.ToListAsync();
            ViewBag.Status = new SelectList(status, "Id", "Name");

            return View(re);
        }

        [Authorize(Roles = "Manager")]
        // GET: Staff/Reservation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
           

            var reservation = await _db.Reservations
                .Include(r => r.Person)
                .Include(r => r.Sitting)
                .ThenInclude(s=>s.SittingType)
                .Include(r => r.Source)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Staff/Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _db.Reservations.FindAsync(id);
            _db.Reservations.Remove(reservation);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _db.Reservations.Any(e => e.Id == id);
        }
    }
}
