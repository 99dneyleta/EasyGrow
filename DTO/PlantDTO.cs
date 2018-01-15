using System.ComponentModel.DataAnnotations;

namespace EasyGrow.DTO
{
    public class PlantDto
    {
        public int? PlantId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Age must be a positive number")]
        public int? Age { get; set; }
        [Required(ErrorMessage = "amount of water is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "AOW must be a positive number")]
        public int? AmountOfWater { get; set; }
        [Required(ErrorMessage = "FOWD is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "FOWD must be a positive number")]
        public int? FrequencyOfWateringDays { get; set; }
        [Required(ErrorMessage = "AFD is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "AOFD must be a positive number")]
        public int? AmountOfFertilizingDays { get; set; }
        [Required(ErrorMessage = "Info is Required")]
        public string Info { get; set; }

        [Required(ErrorMessage = "PhaseId is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Phase Id must be a positive number")]
        public int? PhaseId { get; set; }
        [Required(ErrorMessage = "ClassId is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Class ID must be a positive number")]
        public int? ClassId { get; set; }
        [Required(ErrorMessage = "AC is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Additinal Criteries must be a positive number")]
        public int? AdditinalCriteriesId { get; set; }
    }
}
