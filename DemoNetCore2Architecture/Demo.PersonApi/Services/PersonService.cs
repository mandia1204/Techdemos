using System.Collections.Generic;
using System.Linq;
using Demo.PersonApi.Models;
using Demo.PersonApi.Repositories;

namespace Demo.PersonApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        public PersonService(IPersonRepository personRepository) {
            this.personRepository = personRepository;
        }

        // public Person Create(Person person)
        // {
        //     return personRepository.Create(person);
        // }

        private List<string> ValidatePerson(Person person) {
            var errors = new List<string>();

            if(string.IsNullOrWhiteSpace(person.Name)) {
                errors.Add("Name Id required.");
            }

            if(!person.Courses.Any()) {
                errors.Add("Select at least one course.");
            }

            return errors;
        }

        public ApiResponse<Person> Create(Person person)
        {
            var response = new ApiResponse<Person> {
                Errors = ValidatePerson(person)
            };

            if(!response.Success) {
                return response;
            }

            response.Data = personRepository.Add(person);
            return response;
        }

        public IEnumerable<Person> GetAll()
        {
            return personRepository.GetAll();
        }
    }
}