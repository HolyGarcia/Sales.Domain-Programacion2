
using Sales.Domain.Entities;
using Sales.Infrastructure.Models;

namespace Sales.Infrastructure.Extentions
{
    public static class RolExtention
    {
        public static RolModel ConvertRolEntityToModel( this Rol rol) 
        {
            RolModel rolModel = new RolModel() 
            {
                Descripcion = rol.Descripcion,
                IdRol = rol.IdRol
            };
            return rolModel;
        }
    }
}
