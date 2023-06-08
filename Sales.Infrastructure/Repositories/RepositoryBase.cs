using Sales.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public virtual List<TEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
