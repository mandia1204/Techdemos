using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.PersonApi.Models;

namespace Demo.PersonApi.Repositories.Interfaces
{
    public interface IPersonRepositoryAsync
    {
         Task<List<Person>> GetAllAsync();
         Task<Person> AddAsync(Person person);
         Task<Person> GetByIdAsync(int personId);
         Task RemoveAsync(int personId);
         Task UpdateAsync(Person person);
    }
}