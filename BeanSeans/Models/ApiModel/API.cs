using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSeans.Models.ApiModel
{
    public class API
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public string Source { get; set; }

        public int Guest { get; set; }

        public string Note { get; set; }

        public DateTime StartTime { get; set; }

    }
}
