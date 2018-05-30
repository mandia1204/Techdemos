using System.Collections.Generic;
using System.Linq;
using Demo.PersonApi.DataContexts;
using Demo.PersonApi.Models;

namespace Demo.PersonApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SchoolContext context;
        public PersonRepository(SchoolContext context)
        {
            this.context = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return context.People;
        }
        public Person GetById(int personId)
        {
            return context.People.FirstOrDefault(p => p.PersonId == personId);
        }
        public Person Add(Person person)
        {
            return new Person {
                PersonId = 1234,
                Name = "New person"
            };
        }
        public void Remove(int personId)
        {
            context.Remove(new Person { PersonId = personId});
        }
    }
}