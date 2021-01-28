using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace BeanSeans.Areas.Staff.Models.Staff
{
    public class ManagersVM//to show manager info
    {
        public IdentityUser User { get; set; }

        public IList<string> Roles { get; set; }
    }
}
