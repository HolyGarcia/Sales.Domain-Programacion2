
using Sales.Domain.Entities;
using Sales.Infrastructure.Models;

namespace Sales.Infrastructure.Extentions
{
    public static class UsuarioExtention
    {
        public static UsuarioModel ConvertCourseEntityToModel(this Usuario usuario)
        {
            UsuarioModel usuarioModel = new UsuarioModel()
            {
                Id = usuario.Id,
                Correo = usuario.Correo,
                Nombre = usuario.Nombre,
                IdRol = usuario.IdRol,
                Telefono = usuario.Telefono,
            };
            return usuarioModel;
        }
    }
}
