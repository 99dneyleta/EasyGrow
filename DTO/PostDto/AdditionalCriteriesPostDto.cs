using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGrow.DTO.PostDto
{
    [AtLeastOneProperty(ErrorMessage = "You must supply at least one value")]
    public class AdditionalCriteriesPostDto
    {
        public float? AreaSawn { get; set; }
        
        public int? GroundwaterLevelId { get; set; }
    }
}
