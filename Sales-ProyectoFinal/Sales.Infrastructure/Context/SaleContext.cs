using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Context
{
    public partial class SaleContext : DbContext
    {
        public SaleContext()
        {
            
        }
        public SaleContext(DbContextOptions<SaleContext> options) : base(options)
        {
            
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }
    }
}
