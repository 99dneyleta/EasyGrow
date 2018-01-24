using System.Collections.Generic;

namespace EasyGrow.Models
{
    public class GroundwaterLevel
    {
        public int GroundwaterLevelId { get; set; }
        public string Name { get; set; }

        public ICollection<AdditinalCriteries> AdditinalCriteries { get; set; }
    }
}
