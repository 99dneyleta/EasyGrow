using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGrow.DTO
{
    public class PhaseDto
    {
        public int PhaseId { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
