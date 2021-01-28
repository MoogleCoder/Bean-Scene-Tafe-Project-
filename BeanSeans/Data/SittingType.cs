using System.Collections.Generic;

namespace BeanSeans.Data
{
    public class SittingType
    {//breakfast, lunch, dinner or special
        public int Id { get; set; } //value for dropdown

        public string Name { get; set; }//display

        public List<Sitting> Sittings { get; set; }
        public SittingType()
        {
            Sittings = new List<Sitting>();

        }

    }
}