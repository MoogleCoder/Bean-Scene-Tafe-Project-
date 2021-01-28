using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeanSeans.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeanSeans.Areas.Member.Controllers
{//to show all reservation of  mmembers
    public class ReservationController : MemberAreaController
    {
        //from parent
        public ReservationController(ApplicationDbContext db, UserManager<IdentityUser> um) : base(db, um)
        {

        }

        public async Task<IActionResult> Index()
        {
            //get user from AspUSer
            //see how I get user Id
            //if so is loggined in I can use User!!
            var u = await _userManager.FindByEmailAsync(User.Identity.Name);
            //get member
            var m = await _db.Members.FirstOrDefaultAsync(m => m.UserId == u.Id);
            var reservation = _db.Reservations
                               .Include(r => r.Sitting)
                               .ThenInclude(s => s.SittingType)
                               .Include(r => r.Status)
                               .OrderBy(r => r.StartTime)
                               .Where(r => r.PersonId == m.Id);
            //show reservation

            return View(reservation);
        }           
    }
}

