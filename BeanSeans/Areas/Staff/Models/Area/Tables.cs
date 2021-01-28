using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeanSeans.Data;

namespace BeanSeans.Areas.Staff.Models.Area
{
    //REservationTables
    public class Tables
    {
        //list of  tables
        public List<TableDetails> TableDetails { get; set; } = new List<TableDetails>();

        //list of reservation
        public Data.Reservation Reservation { get;  set; }

     
    }

    //tables

    public class TableDetails
    {
        public int TableId { get; set; }
        public string TableName { get; set; }
        public string AreaName { get; set; }
        public bool Selected { get; set; }

        public DateTime EndTime { get; set; }
    }
}
