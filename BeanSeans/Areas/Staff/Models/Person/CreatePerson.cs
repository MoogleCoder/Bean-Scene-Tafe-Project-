using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSeans.Areas.Staff.Models.Person
{
    public class CreatePerson
    {
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress)]


        public string Email { get; set; }
        [Required, DataType(DataType.PhoneNumber)]

        public string Phone { get; set; }
        public Data.Reservation Reservation { get; set; }

    }
}
