using DataAccessLayer;
using System;

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGenericDataRepository<T> where T : class
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        private DbContext _context; 
        public GenericDataRepository(DbContext context) {
            _context = context;
        }
        public virtual void Add(params T[] items)
        {
            
                foreach (T item in items)
                {
                    _context.Entry(item).State = EntityState.Added;
                }
                _context.SaveChanges();
            
        }

        public virtual void Update(params T[] items)
        {
           
            
                foreach (T item in items)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }
                _context.SaveChanges();
            
        }

        public virtual void Remove(params T[] items)
        {
           
                foreach (T item in items)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                }
                _context.SaveChanges();
            
        }
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
           
                IQueryable<T> dbQuery = _context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            
            return list;
        }

        public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            
                IQueryable<T> dbQuery = _context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            
            return list;
        }

        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
           
                IQueryable<T> dbQuery = _context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            
            return item;
        }
    }
}
