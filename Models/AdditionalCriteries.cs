using System.Collections.Generic;

namespace EasyGrow.Models
{
    public class AdditionalCriteries
    {
        public int AdditionalCriteriesId { get; set; }
        public float AreaSawn { get; set; }

        public int? GroundwaterLevelId { get; set; }

        public ICollection<Plant> Plants { get; set; }
        public GroundwaterLevel GroundwaterLevel { get; set; }
    }
}
