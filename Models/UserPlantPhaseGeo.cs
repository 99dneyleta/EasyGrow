using System.ComponentModel.DataAnnotations;

namespace EasyGrow.Models
{
    public class UserPlantPhaseGeo
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int PlantId { get; set; }
        public Plant Plant { get; set; }

        public int PhaseId { get; set; }
        public Phase Phase { get; set; }

        public int GeolocationId { get; set; }
        public Geolocation Geolocation { get; set; }

        [Timestamp]
        public byte[] Planted { get; set; }
    }
}
