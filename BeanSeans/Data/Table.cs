using System;
using System.Collections.Generic;

namespace BeanSeans.Data
{
    public class Table
    {
        //1 relationship
        //fk
        public int AreaId { get; set; }

        //1 relationship
        public Area Area { get; set; }

        //many relationships
        public List<TableReservation> TableReservations { get; set; }

        public Table()
        {
            TableReservations = new List<TableReservation>();
        }

        //prop
        public int Id { get; set; }

        public string Name { get; set; }


    }
}