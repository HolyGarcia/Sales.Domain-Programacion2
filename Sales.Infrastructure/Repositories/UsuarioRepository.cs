
using Sales.Domain.Entities;
using Sales.Infrastructure.Interfaces;

namespace Sales.Infrastructure.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public List<Usuario> GetUsuariosByIdRol(int id)
        {
            throw new NotImplementedException();
        }
    }
}
