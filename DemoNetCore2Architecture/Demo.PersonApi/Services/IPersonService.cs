using System.Collections.Generic;
using Demo.PersonApi.Models;

namespace Demo.PersonApi.Services
{
    public interface IPersonService
    {
         IEnumerable<Person> GetAll();
         Person GetById(int personId);
         ApiResponse<Person> Create(Person person);
         ApiResponse<Person> Update(Person person);
         ApiResponse<Person> Delete(int personId);
    }
}