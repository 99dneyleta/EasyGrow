using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGrow.Interfaces
{
    public interface IModelService<T,U> where T : class
    {
        List<U> GetAll();
        U Add(U modelDto);
        U Get(int id);
        void Delete(int id);
        U Update(int id, U modelDto);
    }
}
