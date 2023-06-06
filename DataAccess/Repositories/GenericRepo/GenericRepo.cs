using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.GenericRepo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private GenericDAO<T> dao = new GenericDAO<T>();

        public void Delete(object id) => dao.Delete(id);

        public IEnumerable<T> GetAll(string includeProperties) => dao.GetAll(includeProperties);

        public T GetById(object id, string includeProperties, Expression<Func<T, bool>> where) => dao.GetById(id, includeProperties, where);

        public void Insert(T obj) => dao.Insert(obj);

        public void Update(T obj) => dao.Update(obj);
    }
}
