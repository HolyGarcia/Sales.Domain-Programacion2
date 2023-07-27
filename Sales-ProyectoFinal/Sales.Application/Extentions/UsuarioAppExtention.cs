
using Sales.Application.Core;
using Sales.Application.Dtos.Usuario;
using Sales.Domain.Entities;

namespace Sales.Application.Extentions
{
    public static class UsuarioAppExtention
    {
        public static Usuario ConvertUsuarioAddDtoToUsuarioEntity(this UsuarioAddDto usuarioAddDto)
        {
            return new Usuario
            {
                FechaRegistro = usuarioAddDto.FechaRegistro,
                NombreFoto = usuarioAddDto.NombreFoto,
                Clave = usuarioAddDto.Clave,
                Correo = usuarioAddDto.Correo,
                IdUsuarioCreacion = usuarioAddDto.IdUsuarioCreacion,
                EsActivo = usuarioAddDto.EsActivo,
                IdRol = usuarioAddDto.IdRol,
                Nombre = usuarioAddDto.Nombre,
                Telefono = usuarioAddDto.Telefono,
                UrlFoto = usuarioAddDto.UrlFoto
            };
        }
        public static Usuario ConvertUsuarioUpdateDtoToUsuarioEntity(this UsuarioUpdateDto usuarioUpdateDto)
        {
            return new Usuario
            {
                Id = usuarioUpdateDto.Id,
                Nombre = usuarioUpdateDto.Nombre,
                Telefono = usuarioUpdateDto.Telefono,
                IdRol = usuarioUpdateDto.IdRol,
                UrlFoto = usuarioUpdateDto.UrlFoto,
                FechaRegistro = usuarioUpdateDto.FechaRegistro,
                NombreFoto = usuarioUpdateDto.NombreFoto,
                Clave = usuarioUpdateDto.Clave,
                Correo = usuarioUpdateDto.Correo,
                FechaMod = usuarioUpdateDto.FechaMod,
                IdUsuarioMod = usuarioUpdateDto.IdUsuarioMod,
                IdUsuarioCreacion = usuarioUpdateDto.IdUsuarioCreacion,
                EsActivo = usuarioUpdateDto.EsActivo,
            };
        }
        public static Usuario ConvertUsuarioRemoveDtoToUsuarioEntity(this UsuarioRemoveDto usuarioRemoveDto)
        {
            return new Usuario
            {
                Id = usuarioRemoveDto.Id,
                Eliminado = usuarioRemoveDto.Eliminado,
                IdUsuarioElimino = usuarioRemoveDto.IdUsuarioElimino,
                FechaElimino = usuarioRemoveDto.FechaElimino,
            };
        }

        public static ServiceResult IsValidUsuario(this UsuarioDto usuarioDto) 
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(usuarioDto.Nombre))
            {
                result.Message = "El Nombre del usuario es requerido";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(usuarioDto.Correo))
            {
                result.Message = "El Correo del usuario es requerido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(usuarioDto.Clave))
            {
                result.Message = "La Clave del usuario es requerido";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(usuarioDto.Telefono))
            {
                result.Message = "El Telefono del usuario es requerido";
                result.Success = false;
                return result;
            }
            return result;
        }
    }
}
