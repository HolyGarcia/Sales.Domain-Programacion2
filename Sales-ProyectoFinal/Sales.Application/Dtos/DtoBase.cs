
using System;

namespace Sales.Application.Dtos
{
    public abstract class DtoBase
    {
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaRegistro { get; set; }

        public bool? EsActivo { get; set; }
    }
}
