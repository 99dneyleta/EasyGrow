

using System.ComponentModel.DataAnnotations;

namespace EasyGrow.DTO
{
    public class AdditionalCriteriesDto
    {
        [Required]
        public int AdditionalCriteriesId { get; set; }
        public float AreaSawn { get; set; }

        public GroundWaterDto GroundwaterLevel { get; set; }
    }
}
