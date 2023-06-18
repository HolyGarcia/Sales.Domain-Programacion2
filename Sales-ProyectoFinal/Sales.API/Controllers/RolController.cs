using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities;
using Sales.Domain.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository rolRepository;

        public RolController(IRolRepository rolRepository)
        {
            this.rolRepository = rolRepository;
        }
        // GET: api/<RolController>
        [HttpGet("ObtenerRoles")]
        public IActionResult Get()
        {
            var roles = this.rolRepository.GetRols();
            return Ok(roles);
        }

        // GET api/<RolController>/5
        [HttpGet("\"ObtenerRol\"{id}")]
        public IActionResult Get(int id)
        {
            var rol = this.rolRepository.GetRol(id);
            return Ok(rol);
        }

        // POST api/<RolController>
        [HttpPost("GuardarRol")]
        public IActionResult Post([FromBody] Rol rol)
        {
            this.rolRepository.Save(rol);
            return Ok();
        }

        // PUT api/<RolController>/5
        [HttpPut("ActualizarRol")]
        public IActionResult Put([FromBody] Rol rol)
        {
            this.rolRepository.Update(rol);
            return Ok();
        }

        // DELETE api/<RolController>/5
        [HttpDelete("EliminarRol")]
        public IActionResult Eliminar([FromBody] Rol rol)
        {
            this.rolRepository.Remove(rol);
            return Ok();
        }
    }
}
