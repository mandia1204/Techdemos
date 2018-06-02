using System.Collections.Generic;
using Demo.PersonApi.Models;
using Demo.PersonApi.Repositories;

namespace Demo.PersonApi.Services
{
    public class PersonServiceGeneric: IPersonService
    {
        private readonly IPersonRepositoryGeneric personRepository;
        public PersonServiceGeneric(IPersonRepositoryGeneric personRepository) {
            this.personRepository = personRepository;
        }

        public ApiResponse<Person> Create(Person person)
        {
            var response = new ApiResponse<Person> ();

            response.Data = personRepository.Add(person);
            return response;
        }

        public ApiResponse<Person> Delete(int personId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Person GetById(int personId)
        {
            return personRepository.GetById(personId);
        }

        public ApiResponse<Person> Update(Person person)
        {
            throw new System.NotImplementedException();
        }
    }
}