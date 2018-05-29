using System.Collections.Generic;
using Demo.PersonApi.Models;
using Demo.PersonApi.Repositories;

namespace Demo.PersonApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        public PersonService(IPersonRepository personRepository){
            this.personRepository = personRepository;
        }
        public IEnumerable<Person> GetAll()
        {
            return personRepository.GetAll();
        }
    }
}