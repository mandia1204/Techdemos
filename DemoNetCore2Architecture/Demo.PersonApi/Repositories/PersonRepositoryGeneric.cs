using System;
using System.Collections.Generic;
using System.Linq;
using Demo.PersonApi.DataContexts;
using Demo.PersonApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.PersonApi.Repositories
{
    public class PersonRepositoryGeneric : GenericRepository<Person>, IPersonRepositoryGeneric
    {
        public PersonRepositoryGeneric(SchoolContext context) : base(context)
        {
        }

        public Person GetPersonById(int personId)
        {
            return context.People.Include(p => p.Courses)
                .ThenInclude(c => c.Course)
                .Include(p => p.Reviews)
                .SingleOrDefault(p => p.PersonId == personId);
        }

        public override void Update(Person person) {

            HandleListUpdates<Person, PersonCourse>(person, p=> p.Courses);
            HandleListUpdates<Person, Review>(person, p=> p.Reviews);

            context.Update(person);
            context.SaveChanges();
        }
    }
}