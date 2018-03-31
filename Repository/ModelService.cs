using AutoMapper;
using EasyGrow.Data;
using EasyGrow.Helpers;
using EasyGrow.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EasyGrow.Repository
{
    public class ModelService<T,U,P> : IModelService<T,U,P> where T : class
    {
        private readonly DbSet<T> _thisInstance;
        private readonly PlantContext _context;

        public ModelService(PlantContext context)
        {
            _context = context;
            _thisInstance = context.Set<T>();
        }

        public virtual async Task<List<U>> GetAllAsync()
        {
            var allModels =  await _thisInstance.ToListAsync();
            var allModelsDto = allModels.Select(element => Mapper.Map<U>(element)).ToList();
            return allModelsDto;
        }

        public virtual async Task<U> GetAsync(int id)
        {   
            return Mapper.Map<U>(await _thisInstance.FindAsync(id));
        }

        public virtual async Task<U> AddAsync(P modelDto)
        {
            var model = Mapper.Map<T>(modelDto);
            var res = await _thisInstance.AddAsync(model);
            await res.Context.SaveChangesAsync();
            return Mapper.Map<U>(model);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var model = await _thisInstance.FindAsync(id);
            var res = _thisInstance.Remove(model);
            await res.Context.SaveChangesAsync();
        }

        public virtual async Task<U> UpdateAsync(int id, P modelDto)
        {
            var notNullProperties = new Dictionary<string, string>();
            var model = await _thisInstance.FindAsync(id);

            if (model == null) return default(U);

            foreach (PropertyInfo propertyInfo in modelDto.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(modelDto);

                if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                    notNullProperties[propertyInfo.Name] = value.ToString();
            }

            foreach (PropertyInfo propertyInfo in model.GetType().GetProperties())
            {
                var propertyName = propertyInfo.Name;

                if (notNullProperties.ContainsKey(propertyName))
                {
                    Type t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                    object safeValue = (notNullProperties[propertyName] == null) ? null : Convert.ChangeType(notNullProperties[propertyName], t);
                    propertyInfo.SetValue(model, safeValue, null);
                    
                }
            }
            var res = _thisInstance.Update(model);
            await res.Context.SaveChangesAsync();
            return await GetAsync(id);
        }

    }
}
