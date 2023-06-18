using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities;
using Sales.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
        // GET: api/<UsuarioController>
        [HttpGet("ObtenerUsuarios")]
        public IActionResult Get()
        {
            var usuarios = usuarioRepository.GetUsuarios(); 
            return Ok(usuarios);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("\"ObtenerUsuario\"{id}")]
        public IActionResult Get(int id)
        {
            var usuarios = usuarioRepository.GetUsuario(id);
            return Ok(usuarios);
        }
        // GET api/<UsuarioController>/5
        [HttpGet("ObtenerUsuarioByIdRol")]
        public IActionResult GetByIdRol(int idRol)
        {
            var usuarios = usuarioRepository.GetUsuariosByIdRol(idRol);
            return Ok(usuarios);
        }

        // POST api/<UsuarioController>
        [HttpPost("AgregarUsuario")]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            usuarioRepository.Save(usuario);
            return Ok();
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("ActualizarUsuario")]
        public IActionResult Put([FromBody] Usuario usuario)
        {
            usuarioRepository.Update(usuario);
            return Ok();
        }
        // DELETE api/<RolController>/5
        [HttpDelete("EliminarUsuario")]
        public IActionResult Remove([FromBody] Usuario usuario)
        {
            this.usuarioRepository.Remove(usuario);
            return Ok();
        }

    }
}
