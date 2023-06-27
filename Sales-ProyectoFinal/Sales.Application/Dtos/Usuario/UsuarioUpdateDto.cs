
using System;

namespace Sales.Application.Dtos.Usuario
{
    public class UsuarioUpdateDto : UsuarioDto
    {
        public int Id { get; set; }
        public int? IdUsuarioMod { get; set; }
        public DateTime? FechaMod { get; set; }
    }
}
