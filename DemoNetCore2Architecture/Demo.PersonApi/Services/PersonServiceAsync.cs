using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.PersonApi.Models;
using Demo.PersonApi.Repositories.Interfaces;

namespace Demo.PersonApi.Services
{
    public class PersonServiceAsync: IPersonServiceAsync
    {
        private readonly IPersonRepositoryAsync personRepository;
        public PersonServiceAsync(IPersonRepositoryAsync personRepository) {
            this.personRepository = personRepository;
        }

        public async Task<ApiResponse<Person>> CreateAsync(Person person)
        {
            var response = new ApiResponse<Person> {
                Errors = ValidatePerson(person, true)
            };

            if(!response.Success) {
                return response;
            }

            response.Data = await personRepository.AddAsync(person);
            return response;
        }

        public async Task<ApiResponse<Person>> DeleteAsync(int personId)
        {
            await personRepository.RemoveAsync(personId);
            return new ApiResponse<Person>();
        }

        public Task<List<Person>> GetAllAsync()
        {
             return personRepository.GetAllAsync();
        }

        public Task<Person> GetByIdAsync(int personId)
        {
            return personRepository.GetByIdAsync(personId);
        }

        public async Task<ApiResponse<Person>> UpdateAsync(Person person)
        {
            var response = new ApiResponse<Person> {
                Errors = ValidatePerson(person, false)
            };

            if(!response.Success) {
                return response;
            }

            await personRepository.UpdateAsync(person);
            response.Data = person;

            return response;
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
    }
}