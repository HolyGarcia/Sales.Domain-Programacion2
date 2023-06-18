using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sales.Domain.Repository;
using Sales.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SaleContext context;
        private readonly DbSet<TEntity> myDbset;
        public RepositoryBase(SaleContext context)
        {
            this.context = context;
            this.myDbset = this.context.Set<TEntity>();
        }

        public virtual List<TEntity> GetEntities()
        {
            return myDbset.ToList();
        }

        public virtual TEntity GetEntityById(int id)
        {
            return myDbset.Find(id);
        }

        public virtual void Save(TEntity entity)
        {
            this.myDbset.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.myDbset.Update(entity);
        }
        public virtual void SaveChanges() 
        {
            this.context.SaveChanges();
        }

        public virtual void Remove(TEntity entity)
        {
            this.myDbset.Update(entity);
        }
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.myDbset.Any(filter);
        }

    }
}
