
using Microsoft.Extensions.Logging;
using Sales.Application.Contract;
using Sales.Application.Core;
using Sales.Application.Dtos.Rol;
using Sales.Domain.Entities;
using Sales.Domain.Repository;

namespace Sales.Application.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository rolRepository;
        private readonly ILogger<RolService> logger;

        public RolService(IRolRepository rolRepository, ILogger<RolService> logger)
        {
            this.rolRepository = rolRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = rolRepository.GetRols();
                result.Message = "Los Roles Fueron Obtenidos Exitosamente!!";
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Error Obteniendo Los Roles";
                logger.LogError($"{ex.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {

            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = rolRepository.GetRol(id);
                result.Message = "El Rol Fue Obtenido Exitosamente!!";
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Error Obteniendo el Rol";
                logger.LogError($"{ex.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(RolRemoveDto model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Rol rolToRemove = new Rol();
                var id = this.GetById(model.IdRol);
                if (id == null)
                {
                    result.Message = "El Id del Rol No existe en la BD";
                }
                else 
                {
                    rolToRemove.IdRol = model.IdRol;
                    rolToRemove.IdUsuarioElimino = model.IdUsuarioElimino;
                    rolToRemove.Eliminado = model.Eliminado;
                    rolToRemove.FechaElimino = model.FechaElimino;
                    result.Message = "El Rol Fue Agregado Exitosamente!!";
                }

            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Error Eliminando el Rol";
                logger.LogError($"{ex.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(RolAddDto model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (string.IsNullOrEmpty(model.Descripcion))
                {
                    result.Message = "La Descripcion del rol es requerido";
                    result.Success = false;
                    return result;
                }
                if (model.Descripcion.Length > 30 ) 
                {
                    result.Message = "La longitud de la Descripcion No puede ser mayor a 30";
                    result.Success = false;
                    return result;
                }

                rolRepository.Save(new Domain.Entities.Rol 
                {
                    FechaRegistro = model.FechaRegistro,
                    EsActivo = model.EsActivo,
                    Descripcion = model.Descripcion,
                    IdUsuarioCreacion = model.IdUsuarioCreacion
                });
                result.Message = "El Rol Fue Agregado Exitosamente!!";
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Error Guardando el Rol";
                logger.LogError($"{ex.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(RolUpdateDto model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Rol rolToUpdate = new Rol();
                var id = this.GetById(model.IdRol);
                if (id == null)
                {
                    result.Message = "El Id del Rol No existe en la BD";
                }
                else
                {
                    rolToUpdate.IdRol = model.IdRol;
                    rolToUpdate.FechaRegistro = model.FechaRegistro;
                    rolToUpdate.EsActivo = model.EsActivo;
                    rolToUpdate.Descripcion = model.Descripcion;
                    rolToUpdate.FechaMod = model.FechaMod;
                    rolToUpdate.IdUsuarioMod = model.IdUsuarioMod;
                    rolToUpdate.IdUsuarioCreacion = model.IdUsuarioCreacion;
                    result.Message = "El Rol Fue Actualizado Exitosamente!!";
                }

            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Error Actualizando el Rol";
                logger.LogError($"{ex.Message}", ex.ToString());
            }
            return result;
        }
    }
}
