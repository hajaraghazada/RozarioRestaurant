using Core.DataRepositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataRepositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();      
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);          
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();          
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);              
            _context.SaveChanges();           
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);            
            _context.SaveChanges();          
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);            
            _context.SaveChanges();          
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();

        }
    }
}
