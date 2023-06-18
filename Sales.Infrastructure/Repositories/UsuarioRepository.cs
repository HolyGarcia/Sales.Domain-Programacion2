
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Extentions;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Models;
using System.Collections.Generic;

namespace Sales.Infrastructure.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly SaleContext context;
        private readonly ILogger<UsuarioRepository> logger;

        public UsuarioRepository(SaleContext context, ILogger<UsuarioRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        public List<UsuarioModel> GetUsuarios()
        {
            List<UsuarioModel> usuarios = new List<UsuarioModel>();

            try
            {
                usuarios = (from us in base.GetEntities()
                          where !us.Eliminado
                          select new UsuarioModel()
                          {
                              Correo= us.Correo,
                              Id = us.Id,
                              IdRol=us.IdRol,
                              Nombre = us.Nombre,
                              Telefono=us.Telefono
                          }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error obeteniendo los cursos: {ex.Message}", ex.ToString());
            }

            return usuarios;

        }
        public List<UsuarioModel> GetUsuariosByIdRol(int idRol)
        {
            List <UsuarioModel> usuarios = new List<UsuarioModel>();
            try
            {
                usuarios = (from us in base.GetEntities()
                            join rl in context.Rol.ToList() on us.IdRol equals rl.IdRol
                            where rl.IdRol == idRol
                            && !us.Eliminado
                            select new UsuarioModel() 
                            {
                                Id = us.Id,
                                Correo = us.Correo,
                                IdRol = rl.IdRol,
                                Nombre = us.Nombre,
                                Telefono = us.Telefono
                            }).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message}", ex.ToString());
            }
            return usuarios;
        }
        public override void Save(Usuario entity)
        {
            try
            {
                Usuario usuarioSave = new Usuario() 
                {
                    Correo = entity.Correo,
                    IdRol = entity.IdRol,
                    Clave = entity.Clave,
                    Nombre = entity.Nombre,
                    NombreFoto = entity.NombreFoto,
                    IdUsuarioCreacion = entity.IdUsuarioCreacion,
                    EsActivo = entity.EsActivo,
                    UrlFoto = entity.UrlFoto,
                    FechaRegistro = entity.FechaRegistro,
                    Telefono = entity.Telefono,

                };
                base.Save(usuarioSave);
                base.SaveChanges();
                
            }
            catch (Exception ex)
            {
                logger.LogError($"Error Guardando el Usuario {ex.Message}", ex.ToString());
            }
            
        }
        public override void Update(Usuario entity)
        {
            try
            {
                Usuario usuarioToUpdate = base.GetEntityById(entity.Id);
                if (usuarioToUpdate is null)
                    throw new UsuarioException("El Usuario no existe.");
                else 
                {
                    usuarioToUpdate.Correo = entity.Correo;
                    usuarioToUpdate.Clave = entity.Clave;
                    usuarioToUpdate.EsActivo = entity.EsActivo;
                    usuarioToUpdate.FechaRegistro = entity.FechaRegistro;
                    usuarioToUpdate.Telefono = entity.Telefono;
                    usuarioToUpdate.IdRol = entity.IdRol;
                    usuarioToUpdate.Nombre = entity.Nombre;
                    usuarioToUpdate.NombreFoto = entity.NombreFoto;
                    usuarioToUpdate.UrlFoto = entity.UrlFoto;
                    usuarioToUpdate.FechaMod = DateTime.Now;
                    base.Update(usuarioToUpdate);
                    base.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                logger.LogError($"Error Actualizando el Usuario {ex.Message}", ex.ToString());
            }
        }
        public override void Remove(Usuario entity)
        {
            try
            {
                Usuario usuarioToRemove = base.GetEntityById(entity.Id);
                if (usuarioToRemove is null)
                    throw new UsuarioException("El Usuario no existe.");
                else
                {
                    usuarioToRemove.Eliminado = true;
                    usuarioToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;
                    usuarioToRemove.FechaElimino = entity.FechaElimino;
                    base.Remove(usuarioToRemove);
                    base.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error Eliminando el Usuario {ex.Message}", ex.ToString());
            }
        }
        public UsuarioModel GetUsuario(int id)
        {

            UsuarioModel cursoModel = new UsuarioModel();

            try
            {
                if (!base.Exists(cu => cu.Id == id))
                    throw new Exception("Curso no existe..");
                else
                {
                    cursoModel = base.GetEntityById(id).ConvertCourseEntityToModel();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error Obteniendo el usuario", ex.ToString());
                throw new UsuarioException("Curso no existe..");
            }

            return cursoModel;
        }
    }
}
