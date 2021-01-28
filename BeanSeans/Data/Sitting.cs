using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BeanSeans.Data
{
    public class Sitting
    {
        //1-relationship
        public SittingType SittingType { get; set; }
        //FK
        public int SittingTypeId { get; set; }

        //1-relationship
        public Restuarant Restuarant { get; set; }
        //FK
        public int RestuarantId { get; set; }

        //m-relationship
        public List<Reservation> Reservations { get; set; }

        public Sitting()
        {//instanciate
            Reservations = new List<Reservation>();
        }

        //Prop
        public int Id { get; set; }
        [Required(ErrorMessage = "Start time is required.")]

        public DateTime Start { get; set; }

        [Required(ErrorMessage = "End time is required.")]

        public DateTime End { get; set; }
        [Required(ErrorMessage = "Capacity is required.")]
        public int Capacity { get; set; }

        public int NumberOfGuests { get => Reservations.Sum(r => r.Guest); }

        public int GuestAvailabilityCount { get => Capacity - NumberOfGuests; }




    }
}