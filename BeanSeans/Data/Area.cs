using System.Collections.Generic;

namespace BeanSeans.Data
{
    public class Area
    {
        //1 relationship
        public Restuarant Restuarant { get; set; }
        public int RestuarantId { get; set; }
        //m relationship
        public List<Table> Tables { get; set; }

        public Area()
        {
            Tables = new List<Table>();
        }
        //prop
        public int Id { get; set; }

        public string Name { get; set; }
    }
}