using System;
using System.Collections.Generic;
using System.Linq;
using Demo.PersonApi.Models;
using Demo.PersonApi.Repositories;
using Demo.PersonApi.Repositories.Interfaces;
using FluentValidation;
using FluentValidation.Internal;

namespace Demo.PersonApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IValidator<Person> personValidator;
        public PersonService(IPersonRepository personRepository, IValidator<Person> personValidator) {
            this.personRepository = personRepository;
            this.personValidator = personValidator;
        }

        private List<string> ValidatePerson(Person person, bool isNew) {
            var errors = new List<string>();
            var result = personValidator.Validate(person, ruleSet:isNew ?"new":"*");

            if(!result.IsValid) {
                errors.AddRange(result.Errors.Select(e=> e.ErrorMessage));
            }

            return errors;
        }

        private ApiResponse<Person> ExecuteOperation(Person person, bool isNew, Func<Person, Person> function) {
            var response = new ApiResponse<Person> {
                Errors = ValidatePerson(person, isNew)
            };

            if(!response.Success) {
                return response;
            }

            response.Data = function(person);

            return response;
        }

        public ApiResponse<Person> Create(Person person)
        {
            return ExecuteOperation(person, true, personRepository.Add);
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
            return ExecuteOperation(person, false, personRepository.Update);
        }

        public ApiResponse<Person> Delete(int personId) { 
            personRepository.Remove(personId);
            return new ApiResponse<Person>();
        }
    }
}