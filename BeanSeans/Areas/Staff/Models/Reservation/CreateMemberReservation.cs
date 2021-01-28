using BeanSeans.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSeans.Areas.Staff.Models.Reservation
{
    public class CreateMemberReservation
    {
        protected readonly ApplicationDbContext _db;

        //Person Properties
        [Required]
        public int MemberId { get; set; }

        public SelectList MemberOptions { get; set; }

        //Reservation Properties
        public int SittingId { get; set; }

        public string Sitting { get; set; }

        //var reservations = await _db.Reservations.Where(r => r.SittingId == sitting.Id).ToListAsync();
        ////get sum of resvervations' guests  from the sitting

        //var totalGuest = reservations.Sum(r => r.Guest);
        //var possibleCapacity = sitting.Capacity - totalGuest;

       // public int possibleCapacity { get => (_db.Sittings.FirstOrDefault(s=>s.Id == SittingId).Capacity)-( _db.Reservations.Where(r => r.SittingId == SittingId).Sum(r => r.Guest));
               // }

        //  public int StatusId { get; set; }

        // public string Status { get; set; }

        // public SelectList StatusOptions { get; set; }//using rendering 

        public int SourceId { get; set; }
        public SelectList SourceOptions { get; set; }
        [Required]
        public int Guest { get; set; }
        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        [Range(30, 90, ErrorMessage = "Duration should be 30 min ~ 90 min")]
        public int Duration { get; set; }
        public string Note { get; set; }
    }
}
