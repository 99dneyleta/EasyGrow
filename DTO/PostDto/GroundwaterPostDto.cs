using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGrow.DTO.PostDto
{
    public class GroundWaterPostDto
    {
        [Required]
        public string Name { get; set; }
    }
}
