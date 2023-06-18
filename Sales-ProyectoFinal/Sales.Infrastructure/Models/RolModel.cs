
using System.ComponentModel.DataAnnotations;

namespace Sales.Infrastructure.Models
{
    public class RolModel
    {
        [Key]
        public int IdRol { get; set; }
        public string? Descripcion { get; set; }
    }
}
