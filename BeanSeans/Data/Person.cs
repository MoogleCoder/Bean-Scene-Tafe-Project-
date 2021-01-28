using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeanSeans.Data
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]

        public string LastName { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]

        public string Email { get; set; }

        [Required(ErrorMessage = "A phone number is required.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]

        public string Phone { get; set; }


        //nullable-AspUser
        public string UserId { get; set; }//Guest


        public virtual bool IsMember

        {
            get { return false; }
        }

        public virtual bool IsStaff

        {
            get { return false; }
        }

        //1 relationship
        public Restuarant Restaurant { get; set; }
        //FK
        public int RestuarantId { get; set; }


        public List<Reservation> Reservations { get; set; } = new List<Reservation>();


    }

}
