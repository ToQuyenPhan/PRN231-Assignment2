using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.GenericRepo
{
    public interface IGenericRepo<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        IEnumerable<T> GetAll(string includeProperties);
        void Delete(object id);
        T GetById(object id, string includeProperties, Expression<Func<T, bool>> where);
    }
}
