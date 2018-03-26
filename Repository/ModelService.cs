using AutoMapper;
using EasyGrow.Data;
using EasyGrow.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EasyGrow.Repository
{
    public class ModelService<T,U> : IModelService<T,U> where T : class
    {
        private readonly DbSet<T> _thisInstance;
        private readonly PlantContext _context;

        public ModelService(PlantContext context)
        {
            _context = context;
            //mb Activator create instace<T>
            _thisInstance = context.Set<T>();
        }

        public List<U> GetAll()
        {
            var allModels =  _thisInstance.ToList();
            var allModelsDto = allModels.Select(element => Mapper.Map<U>(element)).ToList();
            return allModelsDto;
        }

        public U Get(int id)
        {   
            return Mapper.Map<U>(_thisInstance.Find(id));
        }

        public U Add(U modelDto)
        {
            var model = Mapper.Map<T>(modelDto);
            var res = _thisInstance.Add(model);
            res.Context.SaveChanges();
            return modelDto;
        }

        public void Delete(int id)
        {
            var model = _thisInstance.Find(id);
            var res = _thisInstance.Remove(model);
            res.Context.SaveChangesAsync();
        }

        public U Update(int id, U modelDto)
        {
            var notNullProperties = new Dictionary<string,string>();
            var model = _thisInstance.Find(id);
            
            foreach (PropertyInfo propertyInfo in modelDto.GetType().GetProperties())
            {
                try {
                    var k = propertyInfo.GetValue(modelDto).ToString();
                }
                catch
                {
                    continue;
                }
                var value = propertyInfo.GetValue(modelDto, null).ToString();
                if (!string.IsNullOrEmpty(value))
                    notNullProperties[propertyInfo.Name] = value;
                }

            foreach(PropertyInfo propertyInfo in model.GetType().GetProperties())
            {

                var propertyName = propertyInfo.Name;
                try
                {
                    var value = propertyInfo.GetValue(model, null).ToString();
                    if (notNullProperties.ContainsKey(propertyName))
                    {
                        propertyInfo.SetValue(model, notNullProperties[propertyName], null);
                        var k = propertyInfo.GetValue(model).ToString();
                    }
                }
                catch
                {
                    continue;
                }
            }
            var res =_thisInstance.Update(model);
            return Get(id);
        }

        


    }
}
