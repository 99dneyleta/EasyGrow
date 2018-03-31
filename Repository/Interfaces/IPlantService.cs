using System.Collections.Generic;
using EasyGrow.DTO;
using EasyGrow.Models;

namespace EasyGrow.Interfaces
{
    public interface IPlantService
    {
        List<Plant> GetAll();
        PlantDto Get(long id);
        PlantDto Create(PlantDto plant);
        PlantDto Update(long id, PlantDto plant);
        PlantDto Delete(long id, string accessToken);
    }
}
