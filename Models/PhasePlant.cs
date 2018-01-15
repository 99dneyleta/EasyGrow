namespace EasyGrow.Models
{
    public class PhasePlant
    {
        public int PhaseId { get; set; }
        public Phase Phase { get; set; }

        public int PlantId { get; set; }
        public Plant Plant { get; set; }
    }
}
