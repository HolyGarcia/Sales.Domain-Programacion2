using Microsoft.AspNetCore.Mvc;
using Sales.Application.Contract;
using Sales.Application.Dtos.Rol;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService rolService;

        public RolController (IRolService rolService)
        {
            this.rolService = rolService;
        }
        // GET: api/<RolController>
        [HttpGet("ObtenerRoles")]
        public IActionResult Get()
        {
            var result = this.rolService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<RolController>/5
        [HttpGet("\"ObtenerRol\"{id}")]
        public IActionResult Get(int id)
        {
            var result = this.rolService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<RolController>
        [HttpPost("GuardarRol")]
        public IActionResult Post([FromBody] RolAddDto rol)
        {
            var result = this.rolService.Save(rol);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<RolController>/5
        [HttpPut("ActualizarRol")]
        public IActionResult Put([FromBody] RolUpdateDto rol)
        {
            var result = this.rolService.Update(rol);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<RolController>/5
        [HttpDelete("EliminarRol")]
        public IActionResult Eliminar([FromBody] RolRemoveDto rol)
        {
            var result = this.rolService.Remove(rol);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
