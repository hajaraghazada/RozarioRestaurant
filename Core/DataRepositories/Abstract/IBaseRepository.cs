using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataRepositories.Abstract
{
    public interface IBaseRepository<T> where T : class, new()
    {
      
        void Add(T entity);                  
        void Update(T entity);              
        void Delete(T entity);               
        T GetById(int id);                  
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
    }
}
