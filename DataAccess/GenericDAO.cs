using BusinessObject.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GenericDAO<T> where T : class
    {
        public GenericDAO()
        {
        }

        public void Update(T obj)
        {
            using (var context = new ProjectParticipatingDbContext())
            {
                context.Set<T>().Attach(obj);
                context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Insert(T obj)
        {
            using (var context = new ProjectParticipatingDbContext())
            {
                context.Set<T>().Add(obj);
                context.SaveChanges();
            }
        }

        public void Delete(object id)
        {
            using (var context = new ProjectParticipatingDbContext())
            {
                T existing = context.Set<T>().Find(id);
                context.Set<T>().Remove(existing);
                context.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll(string includeProperties)
        {
            using (var context = new ProjectParticipatingDbContext())
            {
                if(includeProperties != null)
                {
                    IQueryable<T> query = context.Set<T>();
                    foreach(var includeProperty in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                    return query.ToList();
                }
                return context.Set<T>().ToList();
            }
        }

        public T GetById(object id)
        {
            using (var context = new ProjectParticipatingDbContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            using (var context = new ProjectParticipatingDbContext())
            {
                return context.Set<T>().Where(expression);
            }    
        }
    }
}
