

using Sales.Application.Core;
using Sales.Application.Dtos.Usuario;

namespace Sales.Application.Contract
{
    public interface IUsuarioService : IBaseService<UsuarioAddDto, UsuarioUpdateDto, UsuarioRemoveDto>
    {
        ServiceResult GetByIdRol(int idRol);
    }
}
