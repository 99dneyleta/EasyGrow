using System.Collections.Generic;

namespace EasyGrow.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Name { get; set; }

        public ICollection<Plant> Plants { get; set; }
    }
}
