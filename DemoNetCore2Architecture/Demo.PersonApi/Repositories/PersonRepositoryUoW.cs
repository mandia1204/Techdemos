using System.Collections.Generic;
using Demo.PersonApi.DataContexts;
using Demo.PersonApi.Models;
using Demo.PersonApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.PersonApi.Repositories
{
    public class PersonRepositoryUoW : IPersonRepository
    {
        private readonly SchoolContext context;
        public PersonRepositoryUoW(SchoolContext context) {
            this.context = context;
        }
        public Person Add(Person person)
        {
            context.People.Add(person);
            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            return context.People.AsNoTracking();
        }

        public Person GetById(int personId)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int personId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new System.NotImplementedException();
        }
    }
}