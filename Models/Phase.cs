using System.Collections.Generic;

namespace EasyGrow.Models
{
    public class Phase
    {
        public Phase()
        {
            PhasePlants = new List<PhasePlant>();
            UserPlantPhaseGeo = new List<UserPlantPhaseGeo>();
        }

        public int PhaseId { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }

        public List<PhasePlant> PhasePlants { get; set; }
        public List<UserPlantPhaseGeo> UserPlantPhaseGeo { get; set; }
    }
}
