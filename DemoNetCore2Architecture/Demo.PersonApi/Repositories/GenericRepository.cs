using System;
using System.Collections.Generic;
using System.Linq;
using Demo.PersonApi.DataContexts;
using Demo.PersonApi.Models;
using Demo.PersonApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.PersonApi.Repositories
{
    public abstract class GenericRepository<T>: IGenericRepository<T> where T : class, IEntity
    {
        protected readonly SchoolContext context;

        public GenericRepository(SchoolContext context) {
            this.context = context;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().AsNoTracking();
        }

        public virtual T GetById(int id)
        {
            return context.Set<T>().AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public virtual T Add(T model)
        {
            context.Set<T>().Add(model);

            var id = context.SaveChanges();

            return model;
        }

        public virtual void Remove(int id)
        {
            var toRemove = GetById(id);
            context.Set<T>().Remove(toRemove);
            context.SaveChanges();
        }

        public virtual void Update(T model) {
            context.Set<T>().Update(model);
            context.SaveChanges();
        }

        private List<TL> FilterByRowState<TL> (List<TL> list, RowState state) where TL: IRowState {
            return list.Where(c => c.RowState == state).ToList();
        }

        protected void HandleListUpdates<TL, TCol>(TL obj, Func<TL, List<TCol>> propertySelector) where TCol: class, IRowState {
            FilterByRowState<TCol>(propertySelector(obj), RowState.Added).ForEach(c => context.Set<TCol>().Add(c));
            FilterByRowState<TCol>(propertySelector(obj), RowState.Deleted).ForEach(c => context.Set<TCol>().Remove(c));
        }
    }
}