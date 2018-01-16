using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using EasyGrow.Data;
using EasyGrow.DTO;
using EasyGrow.Helpers;
using EasyGrow.Interfaces;
using EasyGrow.Models;
using Mapper = AutoMapper.Mapper;

namespace EasyGrow.Repository
{
    public class UserService : IUserService
    {
        private readonly PlantContext _context;
        private readonly IPlantService _plantService;

        public UserService(PlantContext context, IPlantService plantService)
        {
            _context = context;
            _plantService = plantService;
        }
        public List<ApplicationUser> GetAll()
        {
            return _context.Users.ToList();
        }

        public ApplicationUser Get(string email)
        {
            return _context.Users.FirstOrDefault(p => p.Email == email);
        }

        public ApplicationUser Update(string email, ApplicationUserDto user)
        {
            var newUser = _context.Users.FirstOrDefault(u => u.Email == email);
            if (newUser == null)
            {
                return null;
            }

            newUser.GeolocationId = user.GeolocationId;

            _context.Users.Update(newUser);
            _context.SaveChanges();

            return newUser;
        }

        public ApplicationUser Delete(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return user;
        }

        public PlantDto AddPlantToUser(string accessToken, long plantId)
        {
            var newUserPlant = new UserPlants
            {
                ApplicationUser = JwtHelper.GetUserJwt(accessToken, _context)
            };

            var plant = _plantService.Get(plantId);
            newUserPlant.Plant = Mapper.Map<Plant>(plant);
            var plantDto = Mapper.Map<PlantDto>(plant);

            _context.UserPlants.Add(newUserPlant);
            _context.SaveChanges();

            return plantDto;
        }

        public PlantDto RemovePlantFromUser(string accessToken, long plantId)
        {
            var newUserPlant = new UserPlants
            {
                ApplicationUser = JwtHelper.GetUserJwt(accessToken, _context)
            };

            var plant = _plantService.Get(plantId);
            newUserPlant.Plant = Mapper.Map<Plant>(plant);

            _context.UserPlants.Remove(newUserPlant);
            return Mapper.Map<PlantDto>(plant);
        }

        public List<PlantDto> GetAllUserPlants(string accessToken)
        {
            var user = JwtHelper.GetUserJwt(accessToken, _context);
            if (user == null)
            {
                return null;
            }


            var userplants = _context.UserPlants.Where(x => x.ApplicationUser == user).ToList();

            return userplants.Select(element => Mapper.Map<PlantDto>(_context.Plants.FirstOrDefault(r => r.PlantId == element.PlantId))).ToList();
        }
    }
}
