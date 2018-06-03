using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.PersonApi.DataContexts;
using Demo.PersonApi.Models;
using Demo.PersonApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.PersonApi.Repositories
{
    public class PersonRepositoryAsync : IPersonRepositoryAsync
    {
        private readonly SchoolContext context;
        public PersonRepositoryAsync(SchoolContext context)
        {
            this.context = context;
        }

        public async Task<Person> AddAsync(Person person)
        {
            context.People.Add(person);

            var id = await context.SaveChangesAsync();

            return  person;
        }

        public Task<List<Person>> GetAllAsync()
        {
            return context.People.AsNoTracking().ToListAsync();
        }

        public Task<Person> GetByIdAsync(int personId)
        {
            return context.People.Include(p => p.Courses)
                .ThenInclude(c => c.Course)
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(p => p.PersonId == personId);
        }

        public Task RemoveAsync(int personId)
        {
            context.Remove(new Person { PersonId = personId});
            return context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            HandleListUpdates<Person, PersonCourse>(person, p=> p.Courses);
            HandleListUpdates<Person, Review>(person, p=> p.Reviews);

            context.Update(person);
            await context.SaveChangesAsync();
        }

        private List<T> FilterByRowState<T> (List<T> list, RowState state) where T: IRowState {
            return list.Where(c => c.RowState == state).ToList();
        }

        private void HandleListUpdates<T, TCol>(T obj, Func<T, List<TCol>> propertySelector) where TCol: class, IRowState {
            FilterByRowState<TCol>(propertySelector(obj), RowState.Added).ForEach(c => context.Set<TCol>().Add(c));
            FilterByRowState<TCol>(propertySelector(obj), RowState.Deleted).ForEach(c => context.Set<TCol>().Remove(c));
        }
    }
}