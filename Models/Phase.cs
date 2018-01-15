using System.Collections.Generic;

namespace EasyGrow.Models
{
    public class Phase
    {
        public Phase()
        {
            PhasePlants = new List<PhasePlant>();
        }

        public int PhaseId { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }

        public Plant Plant { get; set; }
        public List<PhasePlant> PhasePlants { get; set; }
    }
}
