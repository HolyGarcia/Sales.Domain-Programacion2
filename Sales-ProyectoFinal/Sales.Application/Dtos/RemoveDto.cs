

using System;

namespace Sales.Application.Dtos
{
    public abstract class RemoveDto
    {
        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }
    }
}
