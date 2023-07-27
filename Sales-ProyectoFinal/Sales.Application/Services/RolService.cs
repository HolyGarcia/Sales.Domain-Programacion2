
using Microsoft.Extensions.Logging;
using Sales.Application.Contract;
using Sales.Application.Core;
using Sales.Application.Dtos.Rol;
using Sales.Application.Extentions;
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
                var id = this.GetById(model.IdRol);
                if (id == null)
                {
                    result.Message = "El Id del Rol No existe en la BD";
                    return result;
                }
                else 
                {
                    rolRepository.Remove(model.ConvertRolRemoveDtoToRolEntity());
                    result.Message = "El Rol Fue Eliminado Exitosamente!!";
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
                if(!model.IsValidRol().Success)
                    return result;

                rolRepository.Save(model.ConvertRolAddDtoToRolEntity());
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
                if (!model.IsValidRol().Success)
                    return result;

                var id = this.GetById(model.IdRol);
                if (id == null)
                {
                    result.Message = "El Id del Rol No existe en la BD";
                    return result;
                }
                else
                {
                    rolRepository.Update(model.ConvertRolUpdateDtoToRolEntity());
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
