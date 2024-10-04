using Core.DataRepositories.Abstract;
using Core.DataRepositories.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EFUnitofWork : IUnitOfWork
    {
        public RozarioContext RozarioContext { get; set; }

        public EFUnitofWork(RozarioContext rozarioContext)
        {
            RozarioContext = rozarioContext;
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new() 
        {
            return new BaseRepository<TEntity>(RozarioContext);
        }

        public void SaveChanges()
        {
            RozarioContext.SaveChanges();
        }
    }
    
}
