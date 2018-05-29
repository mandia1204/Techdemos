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

        // public Person Create(Person person)
        // {
        //     return personRepository.Create(person);
        // }

        public ApiResponse<Person> Create(Person person)
        {
            var response = new ApiResponse<Person>();

            if(person.PersonId == 0) {
                response.Errors.Add("Person Id required");
            }

            if(!response.Success) {
                return response;
            }

            response.Data = personRepository.Create(person);
            return response;
        }

        public IEnumerable<Person> GetAll()
        {
            return personRepository.GetAll();
        }
    }
}