using Sales.Domain.Core;


namespace Sales.Domain.Entities
{
    public partial class Categoria : BaseEntity
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
    }
}
