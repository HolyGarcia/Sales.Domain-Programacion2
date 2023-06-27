
using System;

namespace Sales.Application.Dtos.Rol
{
    public class RolUpdateDto : RolDto
    {
        public int IdRol { get; set; }
        public int? IdUsuarioMod { get; set; }
        public DateTime? FechaMod { get; set; }
    }
}
