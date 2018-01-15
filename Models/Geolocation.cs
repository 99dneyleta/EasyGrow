using System.Collections.Generic;

namespace EasyGrow.Models
{
    public class Geolocation
    {
        public int GeolocationId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SeaLevel { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
