using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EasyGrow.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<UserPlantPhaseGeo> UserPlantPhaseGeo { get; set; }
    }
}
