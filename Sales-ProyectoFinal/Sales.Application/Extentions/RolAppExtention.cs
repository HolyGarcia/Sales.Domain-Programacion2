using Sales.Application.Core;
using Sales.Application.Dtos.Rol;
using Sales.Domain.Entities;
namespace Sales.Application.Extentions
{
    public static class RolAppExtention
    {
        public static Rol ConvertRolAddDtoToRolEntity(this RolAddDto rolAddDto)
        {
            return new Rol
            {

                FechaRegistro = rolAddDto.FechaRegistro,
                EsActivo = rolAddDto.EsActivo,
                Descripcion = rolAddDto.Descripcion,
                IdUsuarioCreacion = rolAddDto.IdUsuarioCreacion
            };
        }
        public static Rol ConvertRolUpdateDtoToRolEntity(this RolUpdateDto rolDto)
        {
            return new Rol
            {
                IdRol = rolDto.IdRol,
                FechaRegistro = rolDto.FechaRegistro,
                EsActivo = rolDto.EsActivo,
                Descripcion = rolDto.Descripcion,
                FechaMod = rolDto.FechaMod,
                IdUsuarioMod = rolDto.IdUsuarioMod,
                IdUsuarioCreacion = rolDto.IdUsuarioCreacion
            };
        }
        public static Rol ConvertRolRemoveDtoToRolEntity(this RolRemoveDto rolRemoveDto)
        {
            return new Rol
            {
                IdRol = rolRemoveDto.IdRol,
                IdUsuarioElimino = rolRemoveDto.IdUsuarioElimino,
                Eliminado = rolRemoveDto.Eliminado,
                FechaElimino = rolRemoveDto.FechaElimino
            };
        }
        public static ServiceResult IsValidRol(this RolDto rol) 
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(rol.Descripcion))
            {
                result.Message = "La Descripcion del rol es requerido";
                result.Success = false;
                return result;
            }
            if (rol.Descripcion.Length > 30)
            {
                result.Message = "La longitud de la Descripcion No puede ser mayor a 30";
                result.Success = false;
                return result;
            }
            return result;
        } 
    }
}
