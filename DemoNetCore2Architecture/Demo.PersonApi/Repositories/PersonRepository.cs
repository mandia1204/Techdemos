using System;
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
            context.People.Add(person);

            var id = context.SaveChanges();

            return person;
        }

        public void Update(Person person) {
            Func<RowState, List<PersonCourse>> filterCourses = (RowState state) => person.Courses.Where(c =>c.RowState == state).ToList();

            var added = filterCourses(RowState.Added);
            var deleted = filterCourses(RowState.Deleted);
            //Add new courses
            added.ForEach(a => context.PersonCourses.Add(a));
            //delete courses
            deleted.ForEach(a => context.PersonCourses.Remove(a));

            context.Update(person);
            context.SaveChanges();
        }

        public void Remove(int personId)
        {
            context.Remove(new Person { PersonId = personId});
            context.SaveChanges();
        }
    }
}