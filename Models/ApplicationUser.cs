using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EasyGrow.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int GeolocationId { get; set; }
        public int? PlantId { get; set; }

        public Geolocation Geolocation { get; set; }
        public Plant Plant { get; set; }

        public List<UserPlants> UserPlants { get; set; }
    }
}
