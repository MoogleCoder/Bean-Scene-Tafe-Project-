using BeanSeans.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSeans.Models.Reservation
{
    public class CreateReservation
    {
        public Data.Person Person { get; set; }

        public Sitting Sitting { get; set; }
//only for manager to make guest reservation
        public int SourceId { get; set; }
        public SelectList SourceOptions { get; set; }
        [Required]
        public int Guest { get; set; }
        [Required]
        public DateTime Time { get; set; }
 
        public string Note { get; set; }


        [Required]
        [Range(30, 90, ErrorMessage = "Duration should be 30 min ~ 90 min")]
        public int Duration { get; set; }

    }
}
