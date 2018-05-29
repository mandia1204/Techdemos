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

        public Person Create(Person person)
        {
            return new Person {
                PersonId = 1234,
                Name = "New person"
            };
        }

        public IEnumerable<Person> GetAll()
        {
            return context.People;
        }
    }
}