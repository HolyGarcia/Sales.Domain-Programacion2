using Microsoft.Extensions.Logging;
using Sales.Application.Contract;
using Sales.Application.Core;
using Sales.Application.Dtos.Usuario;
using Sales.Domain.Entities;
using Sales.Infrastructure.Interfaces;
using System;

namespace Sales.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogger<UsuarioService> logger;

        public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<UsuarioService> logger)
        {
            this.usuarioRepository = usuarioRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = usuarioRepository.GetUsuarios();
                result.Message = "Usuarios Obtenidos Exitosamente!!";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error Guardando el Usuarios";
                logger.LogError($"{ex.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = usuarioRepository.GetUsuario(id);
                result.Message = "Usuario Obtenido Exitosamente!!";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error Obteniendo el Usuario";
                logger.LogError($"{ex.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetByIdRol(int idRol)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = usuarioRepository.GetUsuariosByIdRol(idRol);
                result.Message = "Usuarios Obtenidos Exitosamente!!";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error Obteniendo los Usuarios Por el IdRol";
                logger.LogError($"{ex.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(UsuarioRemoveDto model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Usuario usuarioToRemove = new Usuario();
                var id = this.GetById(model.Id);
                if (id == null)
                {
                    result.Message = "El Id del Usuario No existe en la BD";
                }
                else
                {
                    usuarioToRemove.Id = model.Id;
                    usuarioToRemove.Eliminado = model.Eliminado;
                    usuarioToRemove.IdUsuarioElimino = model.IdUsuarioElimino;
                    usuarioToRemove.FechaElimino = model.FechaElimino;
                    usuarioRepository.Remove(usuarioToRemove);
                    result.Message = "El Usuario Fue Eliminado Exitosamente!!";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error Eliminando el Usuario";
                logger.LogError($"{ex.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(UsuarioAddDto model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (string.IsNullOrEmpty(model.Nombre))
                {
                    result.Message = "El Nombre del usuario es requerido";
                    result.Success = false;
                    return result;
                }
                if (string.IsNullOrEmpty(model.Correo))
                {
                    result.Message = "El Correo del usuario es requerido";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(model.Clave))
                {
                    result.Message = "La Clave del usuario es requerido";
                    result.Success = false;
                    return result;
                }
                if (string.IsNullOrEmpty(model.Telefono))
                {
                    result.Message = "El Telefono del usuario es requerido";
                    result.Success = false;
                    return result;
                }
                usuarioRepository.Save(new Domain.Entities.Usuario
                {
                    FechaRegistro = model.FechaRegistro,
                    NombreFoto = model.NombreFoto,
                    Clave = model.Clave,
                    Correo = model.Correo,
                    IdUsuarioCreacion = model.IdUsuarioCreacion,
                    EsActivo = model.EsActivo,
                    IdRol = model.IdRol,
                    Nombre = model.Nombre,
                    Telefono = model.Telefono,
                    UrlFoto = model.UrlFoto
                });
                result.Message = "El Usuario Fue Agregado Exitosamente!!";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error Guardando el Usuario";
                logger.LogError($"{ex.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(UsuarioUpdateDto model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Usuario usuarioToUpdate = new Usuario();
                var id = this.GetById(model.Id);
                if (id == null)
                {
                    result.Message = "El Id del Usuario No existe en la BD";
                }
                else
                {
                    usuarioToUpdate.Id = model.Id;
                    usuarioToUpdate.Nombre = model.Nombre;
                    usuarioToUpdate.Telefono = model.Telefono;
                    usuarioToUpdate.IdRol = model.IdRol;
                    usuarioToUpdate.UrlFoto = model.UrlFoto;
                    usuarioToUpdate.FechaRegistro = model.FechaRegistro;
                    usuarioToUpdate.NombreFoto = model.NombreFoto;
                    usuarioToUpdate.Clave = model.Clave;
                    usuarioToUpdate.Correo = model.Correo;
                    usuarioToUpdate.FechaMod = model.FechaMod;
                    usuarioToUpdate.IdUsuarioMod = model.IdUsuarioMod;
                    usuarioToUpdate.IdUsuarioCreacion = model.IdUsuarioCreacion;
                    usuarioToUpdate.EsActivo = model.EsActivo;
                    usuarioRepository.Update(usuarioToUpdate);
                    result.Message = "El Usuario Fue Actualizado Exitosamente!!";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error Actualizando el Usuario";
                logger.LogError($"{ex.Message}", ex.ToString());
            }
            return result;
        }
    }
}
