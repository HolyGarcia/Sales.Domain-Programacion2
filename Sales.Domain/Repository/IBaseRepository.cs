using Sales.Domain.Core;


namespace Sales.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
       void Save(TEntity entity);
        void Update(TEntity entity);
        TEntity GetEntityById(int id);
        List<TEntity> GetEntities();
    }
}
