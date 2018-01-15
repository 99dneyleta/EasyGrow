using System.Collections.Generic;

namespace EasyGrow.Models
{
    public class Plant
    {
        public Plant()
        {
            PhasePlants = new List<PhasePlant>();
        }

        public int? PlantId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? AmountOfWater { get; set; }
        public int? FrequencyOfWateringDays { get; set; }
        public int? AmountOfFertilizingDays { get; set; }
        public string Info { get; set; }

        public int? PhaseId { get; set; }
        public int? ClassId { get; set; }
        public int? AdditinalCriteriesId { get; set; }

        public AdditinalCriteries AdditinalCriteries { get; set; }
        public Class Class { get; set; }
        public List<PhasePlant> PhasePlants { get; set; }
        public List<UserPlants> UserPlants { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}
