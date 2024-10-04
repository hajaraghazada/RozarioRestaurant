using Core.DataRepositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork 
    {
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new();
        void SaveChanges();
    }
}
