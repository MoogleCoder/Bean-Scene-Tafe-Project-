using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeanSeans.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeanSeans.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class MemberAreaController : Controller
    {
        protected readonly ApplicationDbContext _db;
        protected readonly UserManager<IdentityUser> _userManager;
        public MemberAreaController(ApplicationDbContext db, UserManager<IdentityUser> um)
        {
            _db = db;
            _userManager = um;

        }
    }
}
