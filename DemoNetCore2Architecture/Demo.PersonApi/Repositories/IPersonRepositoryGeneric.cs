using Demo.PersonApi.Models;

namespace Demo.PersonApi.Repositories
{
    public interface IPersonRepositoryGeneric : IGenericRepository<Person>
    {
         Person GetPersonById(int personId);
    }
}