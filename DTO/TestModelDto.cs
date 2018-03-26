using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGrow.DTO
{
    public class TestModelDto
    {
        public int? TestModelId { get; set; }
        [Required]
        public string Info { get; set; }
    }
}
