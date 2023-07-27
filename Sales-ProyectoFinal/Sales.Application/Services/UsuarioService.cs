using Microsoft.Extensions.Logging;
using Sales.Application.Contract;
using Sales.Application.Core;
using Sales.Application.Dtos.Usuario;
using Sales.Application.Extentions;
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
                var id = this.GetById(model.Id);
                if (id == null)
                {
                    result.Message = "El Id del Usuario No existe en la BD";
                }
                else
                {
                    usuarioRepository.Remove(model.ConvertUsuarioRemoveDtoToUsuarioEntity());
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
                if (!model.IsValidUsuario().Success)
                    return result;
                usuarioRepository.Save(model.ConvertUsuarioAddDtoToUsuarioEntity());
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
                if (!model.IsValidUsuario().Success)
                    return result;

                var id = this.GetById(model.Id);
                if (id == null)
                {
                    result.Message = "El Id del Usuario No existe en la BD";
                }
                else
                {
                    usuarioRepository.Update(model.ConvertUsuarioUpdateDtoToUsuarioEntity());
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
