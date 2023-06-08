using Sales.Domain.Entities;
using Sales.Domain.Repository;


namespace Sales.Infrastructure.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        List<Categoria> GetCategoriaById(int Categoria);
    }
}
