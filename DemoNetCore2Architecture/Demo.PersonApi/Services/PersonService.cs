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

        private List<string> ValidatePerson(Person person, bool isNew) {
            var errors = new List<string>();

            if(person.PersonId == 0 && !isNew) {
                 errors.Add("Person Id required.");
            }

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
                Errors = ValidatePerson(person, true)
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

        public Person GetById(int personId)
        {
            return personRepository.GetById(personId);
        }

        public ApiResponse<Person> Update(Person person)
        {
            var response = new ApiResponse<Person> {
                Errors = ValidatePerson(person, false)
            };

            if(!response.Success) {
                return response;
            }

            personRepository.Update(person);
            response.Data = person;

            return response;
        }

        public ApiResponse<Person> Delete(int personId) { 
            personRepository.Remove(personId);
            return new ApiResponse<Person>();
        }
    }
}