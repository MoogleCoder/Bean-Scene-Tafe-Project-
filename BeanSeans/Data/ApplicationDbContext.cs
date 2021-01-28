using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeanSeans.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Sitting> Sittings { get; set; }

        public DbSet<Restuarant> Restuarants { get; set; }
        public DbSet<ReservationStatus> ReservationStatuses { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<ReservationSource> ReservationSources { get; set; }

        public DbSet<SittingType> SittingTypes { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<TableReservation> TableReservations { get; set; }


    }
}
