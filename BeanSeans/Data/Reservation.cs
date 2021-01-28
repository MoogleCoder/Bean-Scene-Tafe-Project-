using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSeans.Data
{
    public class Reservation
    {
        public int PersonId { get; set; }//1,1 relationship
        public Person Person { get; set; }//1 relationship

        public int SittingId { get; set; }//1 relationship

        public Sitting Sitting { get; set; }//1,1 relationship
        //1-relationship
        public int StatusId { get; set; }
        //1-relationship
        public ReservationStatus Status { get; set; }


        //1-relationship: FK
        public int SourceId { get; set; }
        public ReservationSource Source { get; set; }

        //m
        public List<TableReservation> TableReservations { get; set; }
        public Reservation()
        {
            TableReservations = new List<TableReservation>();
        }


        public int Id { get; set; }
        [Required(ErrorMessage = "Number of guest is required.")]
        public int Guest { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        //this is the duration of reservation in mins
        //60==1h
        [Range(30, 90, ErrorMessage = "Duration should be 30 min ~ 90 min")]

        public int Duration { get; set; }

        [NotMapped]
        public DateTime EndTime { get => StartTime.AddMinutes(Duration); }
        public string Note { get; set; }

    }
}