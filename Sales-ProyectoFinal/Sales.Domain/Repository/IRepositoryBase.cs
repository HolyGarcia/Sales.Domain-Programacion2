using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        TEntity GetEntityById(int id);
        List<TEntity> GetEntities();
        void Remove(TEntity entity);
        bool Exists(Expression<Func<TEntity, bool>> filter);
    }
}
