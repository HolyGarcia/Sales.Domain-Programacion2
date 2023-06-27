using Microsoft.AspNetCore.Mvc;
using Sales.Application.Contract;
using Sales.Application.Dtos.Usuario;
using Sales.Application.Services;
using Sales.Domain.Entities;
using Sales.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }
        // GET: api/<UsuarioController>
        [HttpGet("ObtenerUsuarios")]
        public IActionResult Get()
        {
            var result = usuarioService.GetAll();
            if (!result.Success)
            {
                BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("\"ObtenerUsuario\"{id}")]
        public IActionResult Get(int id)
        {
            var result = usuarioService.GetById(id);
            if (!result.Success)
            {
                BadRequest(result);
            }
            return Ok(result);
        }
        // GET api/<UsuarioController>/5
        [HttpGet("ObtenerUsuarioByIdRol")]
        public IActionResult GetByIdRol(int idRol)
        {
            var result = usuarioService.GetByIdRol(idRol);
            if (!result.Success)
            {
                BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<UsuarioController>
        [HttpPost("AgregarUsuario")]
        public IActionResult Post([FromBody] UsuarioAddDto usuario)
        {

            var result = usuarioService.Save(usuario);
            if (!result.Success)
            {
                BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("ActualizarUsuario")]
        public IActionResult Put([FromBody] UsuarioUpdateDto usuario)
        {
            var result = usuarioService.Update(usuario);
            if (!result.Success)
            {
                BadRequest(result);
            }
            return Ok(result);
        }
        // DELETE api/<RolController>/5
        [HttpDelete("EliminarUsuario")]
        public IActionResult Remove([FromBody] UsuarioRemoveDto usuario)
        {
            var result = usuarioService.Remove(usuario);
            if (!result.Success)
            {
                BadRequest(result);
            }
            return Ok(result);
        }

    }
}
