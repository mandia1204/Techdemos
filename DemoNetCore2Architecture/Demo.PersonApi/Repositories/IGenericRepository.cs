using System.Collections.Generic;
using Demo.PersonApi.Models;

namespace Demo.PersonApi.Repositories
{
    public interface IGenericRepository<T>
    {
         IEnumerable<T> GetAll();
         T GetById(int id);
         T Add(T model);
         void Remove(int id);
         void Update(T model);
    }
}