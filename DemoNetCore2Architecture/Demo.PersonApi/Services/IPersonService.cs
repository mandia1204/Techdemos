using System.Collections.Generic;
using Demo.PersonApi.Models;

namespace Demo.PersonApi.Services
{
    public interface IPersonService
    {
         IEnumerable<Person> GetAll();
         ApiResponse<Person> Create(Person person);
    }
}