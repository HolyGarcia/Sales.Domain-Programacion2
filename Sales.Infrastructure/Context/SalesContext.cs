using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace Sales.Infrastructure.Context
{
    public partial class SalesContext : DbContext
    {
        public SalesContext() 
        { 
        }

        public SalesContext(DbContextOptions<SalesContext> options) : base(options) 
        {
           
        }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
