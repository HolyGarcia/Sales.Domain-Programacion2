
using Sales.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Entities
{
    public class Rol : BaseEntity
    {
        [Key]
        public int IdRol { get; set; }
        public string? Descripcion { get; set; }
    }
}
