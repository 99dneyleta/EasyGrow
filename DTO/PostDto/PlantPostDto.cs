using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGrow.DTO.PostDto
{
    public class PlantPostDto
    {
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

        [Required(ErrorMessage = "ClassId is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Class ID must be a positive number")]
        public int ClassId { get; set; }
        [Required(ErrorMessage = "AC is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Additinal Criteries must be a positive number")]
        public int? AdditionalCriteriesId { get; set; }
    }
}
