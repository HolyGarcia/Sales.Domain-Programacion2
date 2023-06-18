
using Sales.Domain.Entities;
using Sales.Infrastructure.Models;
using System.Collections.Generic;

namespace Sales.Domain.Repository
{
    public interface IRolRepository : IRepositoryBase<Rol>
    {

        List<RolModel> GetRols();
        RolModel GetRol(int id);
    }
}
