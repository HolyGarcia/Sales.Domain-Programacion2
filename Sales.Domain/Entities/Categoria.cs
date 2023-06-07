using Sales.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Entities
{
    public partial class Categoria : BaseEntity
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
    }
}
