
using Sales.Application.Core;
using Sales.Application.Dtos.Rol;

namespace Sales.Application.Contract
{
    public interface IRolService : IBaseService<RolAddDto, RolUpdateDto, RolRemoveDto>
    {
    }
}
