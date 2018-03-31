using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EasyGrow.Data;
using EasyGrow.DTO;
using EasyGrow.Interfaces;
using EasyGrow.Models;

namespace EasyGrow.Repository
{
    public class PlantService : IPlantService
    {
        private readonly PlantContext _context;


        public PlantService(PlantContext context)
        {
            _context = context;

        }

        public List<Plant> GetAll()
        {
            return _context.Plants.ToList();
        }

        public PlantDto Get(long id)
        {
            return Mapper.Map<PlantDto>(_context.Plants.FirstOrDefault(p => p.PlantId == id));
        }


        public PlantDto Create(PlantDto plantDto)
        {
            var plant = Mapper.Map<Plant>(plantDto);
            _context.Plants.Add(plant);

            _context.SaveChanges();
            return Mapper.Map<PlantDto>(plant);

        }

        public PlantDto Update(long id, PlantDto plant)
        {

            var newPlant = _context.Plants.FirstOrDefault(p => p.PlantId == id);
            if (newPlant == null)
            {
                return null;
            }

            newPlant.AdditionalCriteriesId = plant.AdditionalCriteriesId;
            newPlant.Age = plant.Age;
            newPlant.AmountOfFertilizingDays = plant.AmountOfFertilizingDays;
            newPlant.AmountOfWater = plant.AmountOfWater;
            newPlant.ClassId = plant.ClassId;
            newPlant.FrequencyOfWateringDays = plant.FrequencyOfWateringDays;
            newPlant.Info = plant.Info;
            newPlant.Name = plant.Name;

            _context.Plants.Update(newPlant);
            _context.SaveChanges();

            var plantDto = Mapper.Map<PlantDto>(newPlant);

            return plantDto;
        }

        public PlantDto Delete(long id, string accessToken)
        {
            var plant = _context.Plants.FirstOrDefault(p => p.PlantId == id);
            if (plant == null)
            {
                return null;
            }
            try
            {
                _context.Plants.Remove(plant);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return Mapper.Map<PlantDto>(plant);
        }
    }
}
