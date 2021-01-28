using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeanSeans.Areas.Administration;
using BeanSeans.Areas.Staff.Models.Staff;
using BeanSeans.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeanSeans.Areas.Staff.Controllers
{
    public class EmployeeController : AdministrationAreaController
    {
        public EmployeeController(SignInManager<IdentityUser> sim, UserManager<IdentityUser> um, ApplicationDbContext _db) : base(sim, um, _db)
        {

        }


        public async Task <IActionResult> Index()
        {
            var staffs = await _db.Staffs
                                  .OrderBy(s=>s.FirstName)
                                  .ToListAsync();
            return View(staffs);
        }

        [HttpGet]
        public IActionResult Create()//add view=>Empty tem
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStaff m)//add view=>Empty tem
        {
            if (ModelState.IsValid)
            {
                // get new user info
                var user = new IdentityUser { UserName = m.Email, Email = m.Email, PhoneNumber = m.Phone };
                //set user with passwad
                var result = await _userManager.CreateAsync(user, m.Password);
                if (result.Succeeded)
                {
                    //add role
                    await _userManager.AddToRoleAsync(user, "Staff");
                    //add to staff 
                    var staff = new BeanSeans.Data.Staff
                    {

                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        UserId = user.Id,
                        Email = m.Email,
                        RestuarantId = 1,
                        Phone = m.Phone


                    };


                    _db.Staffs.Add(staff);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }


            
            }




            return View(m);
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Managers()
        {
            //List of Manager VM
            var m = new List<ManagersVM>();

            foreach (var e in _db.Staffs.ToArray())//loop through whole emp to find out manager
            {
                //get user by FindByIdAsync
                var u = await _userManager.FindByIdAsync(e.UserId);
                //get role
                var roles = await _userManager.GetRolesAsync(u);
                //add to the list of Managers
                m.Add(new ManagersVM { User = u, Roles = roles });
            }

            return View(m);//return with the manager MV list
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> PromoteManager(string UserId)
        {
            var u = await _userManager.FindByIdAsync(UserId);
            var roles = await _userManager.GetRolesAsync(u);//get role of user

            if (!roles.Any(roles => roles == "Manager"))
            {
                await _userManager.AddToRoleAsync(u, "Manager");
            }


            return RedirectToAction(nameof(Managers));
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DemoteManager(string UserId)
        {
            //find user by Id
            var u = await _userManager.FindByIdAsync(UserId);
            //get roles of user
            var roles = await _userManager.GetRolesAsync(u);
            if (roles.Any(r => r == "Manager") && roles.Any(r => r == "Staff"))//staff who was promoted
            {
                await _userManager.RemoveFromRoleAsync(u, "Manager");

            }
            if (roles.Any(r => r == "Manager"))//check the role whether manager
            {
                //remove the role
                await _userManager.RemoveFromRoleAsync(u, "Manager");
                await _userManager.AddToRoleAsync(u, "Staff");

            }
          
            return RedirectToAction(nameof(Managers));
        }
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetReport()
        {
            var reservation = await _db.Reservations
                                                    .Include(r => r.Sitting)
                                                     .ThenInclude(rs => rs.SittingType)
                                                    .Include(r => r.Source)
                                                    .Include(r => r.Status)
                                                    .Include(r => r.Person)
                                                    .Where(r=>r.StartTime.Year == DateTime.Today.Year)
                                                    .Where(r=>r.StartTime.Month == DateTime.Today.Month)

                                                    .ToArrayAsync();
            //get a month

            //how many guest total in a month
            //how many reservations in a month
            //how many cancelled reservatios a month
            //source for the reservations
            var guest = 0;
            var numOfReser = reservation.Count();
            var cancelled = 0;
            var online = 0;
            var mobile = 0;
            var email = 0;
            var phone = 0;
           
            for (int i = 0; i < reservation.Length; i++)
            {
                var g = reservation[i].Guest;
                guest = guest + g;
                if (reservation[i].StatusId == 3)//cancelled one
                {
                    cancelled = cancelled + 1;
                }
                if (reservation[i].SourceId ==1)//online booking
                {
                    online = online + 1;
                }
                if (reservation[i].SourceId == 2)//mobile booking
                {
                    mobile = mobile + 1;
                }
                if (reservation[i].SourceId == 3)//email booking
                {
                    email = email + 1;
                }
                if (reservation[i].SourceId == 4)//phone
                {
                    phone = phone + 1;
                }
            }

            ViewBag.Guest = guest;
            ViewBag.Reser = numOfReser;
            ViewBag.Cancelled = cancelled;
            ViewBag.Online = online;
            ViewBag.Mobile = mobile;
            ViewBag.Email = email;
            ViewBag.phone = phone;



            return View(reservation);

        }
    }
}
