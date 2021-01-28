using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSeans.Data
{
    public class Restuarant
    {
        public Restuarant()
        {
            Sittings = new List<Sitting>();
            Areas = new List<Area>();

        }
        public List<Sitting> Sittings { get; set; }
        //m relationship
        public List<Area> Areas { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

    }
}
