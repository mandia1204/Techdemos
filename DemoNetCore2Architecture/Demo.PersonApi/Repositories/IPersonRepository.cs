using System.Collections.Generic;
using Demo.PersonApi.Models;

namespace Demo.PersonApi.Repositories
{
    public interface IPersonRepository
    {
         IEnumerable<Person> GetAll();
    }
}