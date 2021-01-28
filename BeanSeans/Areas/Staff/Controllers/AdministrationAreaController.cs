using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeanSeans.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeanSeans.Areas.Administration
{
    [Area("Staff")]
    [Authorize(Roles = "Staff,Manager")]//only for staff
    public class AdministrationAreaController : Controller
    {
        protected readonly SignInManager<IdentityUser> _signInManager;
        protected readonly UserManager<IdentityUser> _userManager;
        protected readonly ApplicationDbContext _db;

        public AdministrationAreaController(SignInManager<IdentityUser> sim, UserManager<IdentityUser> um, ApplicationDbContext db)
        {
            _signInManager = sim;
            _userManager = um;
            _db = db;
        }

        public AdministrationAreaController()
        {

        }
    }
}
