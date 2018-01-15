using System.Collections.Generic;
using EasyGrow.DTO;
using EasyGrow.Models;

namespace EasyGrow.Interfaces
{
    public interface IUserService
    {
        List<ApplicationUser> GetAll();
        List<PlantDto> GetAllUserPlants(string accessToken);
        ApplicationUser Get(string email);
        ApplicationUser Update(string email, ApplicationUserDto user);
        ApplicationUser Delete(string email);
        PlantDto AddPlantToUser(string accessToken, long plantId);
        PlantDto RemovePlantFromUser(string accessToken, long plantId);
    }
}