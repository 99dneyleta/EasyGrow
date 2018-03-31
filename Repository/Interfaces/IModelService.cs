using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGrow.Interfaces
{
    public interface IModelService<T,U,P> where T : class
    {
        Task<List<U>> GetAllAsync();
        Task<U> AddAsync(P modelDto);
        Task<U> GetAsync(int uid);
        Task DeleteAsync(int uid);
        Task<U> UpdateAsync(int uid, P modelDto);
    }
}
