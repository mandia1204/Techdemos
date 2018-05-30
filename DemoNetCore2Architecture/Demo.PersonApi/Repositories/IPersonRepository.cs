using System.Collections.Generic;
using Demo.PersonApi.Models;

namespace Demo.PersonApi.Repositories
{
    public interface IPersonRepository
    {
         IEnumerable<Person> GetAll();
         Person Add(Person person);
         Person GetById(int personId);
         void Remove(int personId);
    }
}