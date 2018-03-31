using EasyGrow.DTO;
using EasyGrow.DTO.PostDto;
using EasyGrow.Interfaces;
using EasyGrow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGrow.Repository.Interfaces
{
    public interface IAdditionalCriteriesService : IModelService<AdditionalCriteries ,AdditionalCriteriesDto, AdditionalCriteriesPostDto>
    {
        Task<List<AdditionalCriteriesDto>> GetAllCriteriesAsync();
        Task<AdditionalCriteriesDto> GetAdditionalCriteriesAsync(int id);
        Task DeleteForeignKeyAsync(int id);
    }
}
