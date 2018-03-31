using EasyGrow.Data;
using EasyGrow.DTO;
using EasyGrow.DTO.PostDto;
using EasyGrow.Models;
using EasyGrow.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyGrow.Repository
{
    public class AdditionalCriteriesService : ModelService<AdditionalCriteries, AdditionalCriteriesDto, AdditionalCriteriesPostDto>, IAdditionalCriteriesService
    {
        private PlantContext _context;

        public AdditionalCriteriesService(PlantContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AdditionalCriteriesDto>> GetAllCriteriesAsync()
        {
            var allDto = await GetAllAsync();
            foreach (AdditionalCriteriesDto element in allDto)
            {
                if (element.GroundwaterLevel.GroundwaterLevelId != null)
                    element.GroundwaterLevel.Name = _context.GroundwaterLevels.FindAsync(element.GroundwaterLevel.GroundwaterLevelId).Result.Name;
            }
            return allDto;
        }

        public async Task<AdditionalCriteriesDto> GetAdditionalCriteriesAsync(int id)
        {
            var dto = await GetAsync(id);
            if (dto != null && dto.GroundwaterLevel.GroundwaterLevelId != null)
            {
                var name = _context.GroundwaterLevels.FindAsync(dto.GroundwaterLevel.GroundwaterLevelId).Result.Name;
                if (name != null)
                    dto.GroundwaterLevel.Name = name;
            }
            return dto;
        }

        public override async Task<AdditionalCriteriesDto> UpdateAsync(int id, AdditionalCriteriesPostDto model)
        {
            await base.UpdateAsync(id, model);
            return await GetAdditionalCriteriesAsync(id);
        }

        public async Task DeleteForeignKeyAsync(int id)
        {
            var model = await _context.AdditionalCriteries.FindAsync(id);
            if (model != null)
            {
                model.GroundwaterLevelId = null;
                _context.AdditionalCriteries.Update(model);
                await _context.SaveChangesAsync();
            }
        }
    }
}
