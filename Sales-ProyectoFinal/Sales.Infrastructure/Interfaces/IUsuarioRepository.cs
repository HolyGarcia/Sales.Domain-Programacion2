﻿using Sales.Domain.Entities;
using Sales.Domain.Repository;
using Sales.Infrastructure.Models;
using System.Collections.Generic;

namespace Sales.Infrastructure.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        List<UsuarioModel> GetUsuariosByIdRol(int idRol);
        List<UsuarioModel> GetUsuarios();
        UsuarioModel GetUsuario(int id);
    }
}