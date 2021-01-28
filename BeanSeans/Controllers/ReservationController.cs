using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanSeans.Data;
using Microsoft.AspNetCore.Identity;
using BeanSeans.Models.Reservation;
using Microsoft.Extensions.Logging;//1
using System.Diagnostics;
using System.IO;

namespace BeanSeans.Controllers
{
    public class ReservationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ApplicationDbContext _db;
        private readonly ILogger<ReservationController> _logger;//2


        public ReservationController(UserManager<IdentityUser> userManager, ApplicationDbContext db, ILogger<ReservationController> logger)
        {
            _userManager = userManager;
            _db = db;
            _logger = logger;
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

            //  _logger.LogInformation("Log message in the Sittings() method");

            return View(sittings);
        }

        // GET: Reservation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var reservation = await _db.Reservations
                .Include(r => r.Person)
                .Include(r => r.Sitting)
                .ThenInclude(s => s.SittingType)
                .Include(r => r.Source)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.Id == id);

            //assert is for stopping 

            if (reservation == null)
            {

                return NotFound();
            }
            return View(reservation);
        }

        [HttpGet]//id= selected sitting id
        public async Task<IActionResult> Create(int id)
        {
            using (FileStream file = new FileStream("Create.txt", FileMode.Append))
            {
                TextWriterTraceListener listener = new TextWriterTraceListener(file);
                Trace.Listeners.Add(listener);

                //find sitting by id
                var sitting = await _db.Sittings
                                                 .Include(s => s.SittingType)
                                                 .FirstOrDefaultAsync(s => s.Id == id);
                Debug.WriteLine("Opening Debuggin in Sittings");

                Debug.Assert(sitting is { }, "sitting is null");

                if (sitting == null)
                {
                    Debug.WriteLineIf(sitting is null, "sitting is null");

                    //validation
                    return NotFound();
                }


                Debug.WriteLineIf(sitting is { }, "sittingId: " + sitting?.Id + " sittingTypeName: " + sitting?.SittingType.Name + " sitting capacity: " + sitting?.Capacity);
                Debug.Close();
                Trace.Close();
                var m = new CreateReservation
                {
                    Sitting = sitting,
                    Time = sitting.Start,//put the default time as a start time
                    SourceOptions = new SelectList(_db.ReservationSources.ToList(), "Id", "Name")


                };

                if (sitting.SittingTypeId == 4 && !User.IsInRole ("Manager"))//special event can only have rer by manager
                {
                    return View("Error");

                }
                if (User.Identity.IsAuthenticated && User.IsInRole("Member"))
                {//get user if it is member
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    //get person from Created reservation 
                    m.Person = await _db.Members.FirstOrDefaultAsync(m => m.UserId == user.Id);
                }

                return View(m);
            }




        }

        // POST: Reservation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CreateReservation m)
        {
            var sitting = await _db.Sittings.FirstOrDefaultAsync(s => s.Id == m.Sitting.Id);
            Debug.WriteLine("Checking sitting in Create");
            Debug.Assert(sitting is { }, "sitting is  null");//condition, next is if the condition is false

            if (sitting == null)
            {
                return NotFound();
            }
            //time validation
            if (m.Time < sitting.Start || m.Time > sitting.End)
            {
                ModelState.AddModelError("Time", "Invalid Time, must fall within sitting start/end times");
            }
            //guest validation
            if (m.Guest > sitting.GuestAvailabilityCount || m.Guest <= 0)
            {
                ModelState.AddModelError("Guest", "Invaid Guest Number");
            }

            //valid=>
            if (ModelState.IsValid) {
                bool isMember = false;
                Person p;
                if (User.Identity.IsAuthenticated && User.IsInRole("Member"))
                {
                    //get user by name
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);

                    p = await _db.Members.FirstOrDefaultAsync(m => m.UserId == user.Id);
                    isMember = true;

                }

                else//user not login and not member
                {
                    //Add Person
                    p = new Person
                    {
                        FirstName = m.Person.FirstName,
                        LastName = m.Person.LastName,
                        Email = m.Person.Email,
                        Phone = m.Person.Phone,
                        RestuarantId = 1


                    };

                    _db.People.Add(p);
                }
                var r = new Reservation();
                if (User.Identity.IsAuthenticated && (User.IsInRole("Manager") || User.IsInRole("Staff")))
                {
                    r = new Reservation
                    {
                        Guest = m.Guest,
                        StartTime = m.Time,
                        SittingId = sitting.Id,
                       Duration =m.Duration,
                        Note = m.Note,
                        StatusId = 1,//pending
                        SourceId = m.SourceId///Online

                    };
                }
                else
                {
                    //make new reservation
                     r = new Reservation
                    {
                        Guest = m.Guest,
                        StartTime = m.Time,
                        SittingId = sitting.Id,
                      //  Duration = m.Duration,
                        Note = m.Note,
                        StatusId = 1,//pending
                        SourceId = 1,///Online

                    };
                }
           

                //connect reservation and person
                p.Reservations.Add(r);
                //save cahnge
                _db.SaveChanges();

                if (isMember)
                {
                    return RedirectToAction("Index", "Reservation", new { Area = "Member" });
                }
                _logger.LogInformation("Log messae in the httpPost-Create() method");

                return RedirectToAction(nameof(Details), new { id = r.Id });
            }


            //if we got so far, then the model is not valid sp send back create form
            m.SourceOptions = new SelectList(_db.ReservationSources.ToList(), "Id", "Name");
            m.Sitting = sitting;

            return View(m);
        }
            
    }
}
