namespace BeanSeans.Data
{
    public class TableReservation//connection table
    {
        //relationship
        public int TableId { get; set; }
        public Table Table { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        //prop

        public int Id { get; set; }
    }
}