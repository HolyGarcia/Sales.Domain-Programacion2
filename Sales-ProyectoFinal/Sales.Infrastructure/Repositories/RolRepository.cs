
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Domain.Repository;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Extentions;
using Sales.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Infrastructure.Repositories
{
    public class RolRepository : RepositoryBase<Rol>, IRolRepository
    {
        private readonly SaleContext context;
        private readonly ILogger<RolRepository> logger;

        public RolRepository(SaleContext context, ILogger<RolRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public RolModel GetRol(int id)
        {
            RolModel rol = new RolModel();
            try
            {
                if (!base.Exists(cu => cu.IdRol == id))
                    throw new Exception("Usuario no existe..");
                rol = base.GetEntityById(id).ConvertRolEntityToModel();
            }
            catch (System.Exception ex)
            {
                logger.LogError($"Error Obteniendo el Rol {ex.Message}", ex.ToString());
            }
            return rol;
        }

        public List<RolModel> GetRols()
        {
            List<RolModel> roles = new List<RolModel>();

            try
            {
                roles = (from rl in base.GetEntities()
                         where !rl.Eliminado
                         select new RolModel()
                         {
                             Descripcion = rl.Descripcion,
                             IdRol = rl.IdRol
                         }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error obteniendo los Roles: {ex.Message}", ex.ToString());
            }

            return roles;
        }
        public override void Save(Rol entity)
        {
            try
            {
                Rol rolSave = new Rol() 
                {
                    Descripcion = entity.Descripcion,
                    IdUsuarioCreacion = entity.IdUsuarioCreacion,
                    EsActivo = entity.EsActivo,
                    FechaRegistro = entity.FechaRegistro,
                    Eliminado = entity.Eliminado
                };
                base.Save(rolSave);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error Guardando el Rol: {ex.Message}", ex.ToString());
            }
        }
        public override void Remove(Rol entity)
        {
            try
            {
                Rol rolToRemove = base.GetEntityById(entity.IdRol);
                rolToRemove.Eliminado = true;
                rolToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;
                rolToRemove.FechaElimino = entity.FechaElimino;
                base.Remove(rolToRemove);
                base.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error Eliminando el Rol: {ex.Message}", ex.ToString());
            }
        }
        public override void Update(Rol entity)
        {
            try
            {
                Rol rolToUpdate = base.GetEntityById(entity.IdRol);
                rolToUpdate.FechaMod = entity.FechaMod;
                rolToUpdate.Descripcion = entity.Descripcion;
                rolToUpdate.IdUsuarioCreacion = entity.IdUsuarioCreacion;
                rolToUpdate.FechaRegistro = entity.FechaRegistro;
                rolToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                base.Remove(rolToUpdate);
                base.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error Actualizando el Rol: {ex.Message}", ex.ToString());
            }
        }
    }
}
