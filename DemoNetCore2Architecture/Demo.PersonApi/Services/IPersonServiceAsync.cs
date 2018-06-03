using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.PersonApi.Models;

namespace Demo.PersonApi.Services
{
    public interface IPersonServiceAsync
    {
         Task<List<Person>> GetAllAsync();
         Task<Person> GetByIdAsync(int personId);
         Task<ApiResponse<Person>> CreateAsync(Person person);
         Task<ApiResponse<Person>> UpdateAsync(Person person);
         Task<ApiResponse<Person>> DeleteAsync(int personId);
    }
}