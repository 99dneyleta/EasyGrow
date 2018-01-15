namespace EasyGrow.Models
{
    public class UserPlants
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int PlantId { get; set; }
        public Plant Plant { get; set; }
    }
}
