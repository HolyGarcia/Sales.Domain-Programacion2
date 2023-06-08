using Sales.Domain.Entities;
using Sales.Domain.Repository;
using Sales.Infrastructure.Core;


namespace Sales.Infrastructure.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, IBaseRepository<Categoria>
    {
        public override List<Categoria> GetEntities()
        {
            return new List<Categoria>();
        }
       
    }
 
}
