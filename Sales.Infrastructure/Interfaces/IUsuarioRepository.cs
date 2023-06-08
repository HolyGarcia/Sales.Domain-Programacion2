using Sales.Domain.Entities;
using Sales.Domain.Repository;

namespace Sales.Infrastructure.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        List<Usuario> GetUsuariosByIdRol(int id);
    }
}
