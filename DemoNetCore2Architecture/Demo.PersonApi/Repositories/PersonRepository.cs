using System;
using System.Collections.Generic;
using System.Linq;
using Demo.PersonApi.DataContexts;
using Demo.PersonApi.Models;
using Microsoft.EntityFrameworkCore;

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
            return context.People.AsNoTracking();
        }

        public Person GetById(int personId)
        {
            return context.People.Include(p => p.Courses)
                .ThenInclude(c => c.Course)
                .Include(p => p.Reviews)
                .FirstOrDefault(p => p.PersonId == personId);
        }

        public Person Add(Person person)
        {
            context.People.Add(person);

            var id = context.SaveChanges();

            return person;
        }

        private List<T> FilterByRowState<T> (List<T> list, RowState state) where T: IRowState {
            return list.Where(c => c.RowState == state).ToList();
        }

        private void HandleListUpdates<T, TCol>(T obj, Func<T, List<TCol>> propertySelector) where TCol: class, IRowState {
            FilterByRowState<TCol>(propertySelector(obj), RowState.Added).ForEach(c => context.Set<TCol>().Add(c));
            FilterByRowState<TCol>(propertySelector(obj), RowState.Deleted).ForEach(c => context.Set<TCol>().Remove(c));
        }

        public void Update(Person person) {

            HandleListUpdates<Person, PersonCourse>(person, p=> p.Courses);
            HandleListUpdates<Person, Review>(person, p=> p.Reviews);

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