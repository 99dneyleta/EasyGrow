using System.ComponentModel.DataAnnotations;

namespace EasyGrow.DTO
{
    public class GroundWaterDto
    {
        public int? GroundwaterLevelId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
