using System.Collections.Generic;

namespace BeanSeans.Data
{
    public class ReservationSource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Reservation> Reservations { get; set; }

        public ReservationSource()
        {
            Reservations = new List<Reservation>();
        }
    }
}