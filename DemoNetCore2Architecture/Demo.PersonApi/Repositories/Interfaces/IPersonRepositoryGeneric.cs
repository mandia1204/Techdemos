using Demo.PersonApi.Models;

namespace Demo.PersonApi.Repositories.Interfaces
{
    public interface IPersonRepositoryGeneric : IGenericRepository<Person>
    {
         Person GetPersonById(int personId);
    }
}