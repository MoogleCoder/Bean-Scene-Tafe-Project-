using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeanSeans.Data;
using BeanSeans.Models.ApiModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeanSeans.Controllers
{
    [Route("api/{controller}/{action}/{email}")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: api/API
        //[HttpGet]
        //public async Task<ActionResult<Detail>> GetReservations()
        //{
        //    var reservations = await _context.Reservations
        //                              .Include(r => r.Person)
        //                              .Include(r => r.Sitting)
        //                                .ThenInclude(s => s.SittingType)
        //                              .Include(r => r.Source)
        //                              .Include(r => r.Status)
        //                              .ToListAsync();
        //    if (reservations == null)
        //    {
        //        return NotFound();
        //    }

        //    var search = new Detail();
        //    var list = new List<API>();

        //    foreach (var item in reservations)
        //    {
        //        var r = new API
        //        {
        //            Id = item.Id,
        //            FirstName = item.Person.FirstName,
        //            LastName = item.Person.LastName,
        //            Phone = item.Person.Phone,
        //            Email = item.Person.Email,
        //            Guest = item.Guest,
        //            Source = item.Source.Name,
        //            Type = item.Sitting.SittingType.Name,
        //            Note = item.Note,
        //            StartTime = item.StartTime,
        //            Status = item.Status.Name,



        //        };

        //        list.Add(r);
        //        search.Search = list;

        //    }



        //    return search;
        //}
      //  [HttpGet("api/{email}", Name = "GetReservations")]
      [ActionName("GetReservations")]
       //[HttpGet("{email}", Name = "GetReservations")]
        public async Task<ActionResult<Detail>> GetReservations(string email)
        {
            var reservations = await _context.Reservations
                                     .Include(r => r.Person)
                                      .Include(r => r.Sitting)
                                        .ThenInclude(s => s.SittingType)
                                      .Include(r => r.Source)
                                      .Include(r => r.Status)
                                       .Where(r => r.Person.Email == email).ToListAsync();

            if (reservations == null)
            {
                return NotFound();
            }

            var search = new Detail();
            var list = new List<API>();
            foreach (var item in reservations)
            {
                var r = new API
                {
                    Id = item.Id,
                    FirstName = item.Person.FirstName,
                    LastName = item.Person.LastName,
                    Phone = item.Person.Phone,
                    Email = item.Person.Email,
                    Guest = item.Guest,
                    Source = item.Source.Name,
                    Type = item.Sitting.SittingType.Name,
                    Status = item.Status.Name,
                    Note = item.Note,
                    StartTime = item.StartTime

                };

                list.Add(r);
                search.Search = list;
            }
            return search;
        }

      
    }


    public class Detail
    {

        public List<API> Search { get; set; }
    }
}
