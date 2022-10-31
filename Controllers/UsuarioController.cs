using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionAPI.ADO;
using SistemaGestionAPI.Models;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("GetUsuario")]
        public Usuario get(Int32 id)
        {
            return ADO_Usuario.TraerUsuario(id);
        }
        [HttpGet("GetInicioSesion")]
        public Usuario get(string nombreUsuario, string contraseña)
        {
            return ADO_Usuario.IniciarSesion(nombreUsuario, contraseña);
        }
        [HttpPost("CrearUsuario")]
        public void CrearUsuario([FromBody] Usuario usuario)
        {
            ADO_Usuario.CrearUsuario(usuario);

        }
        [HttpPut("ActualizarUsuario")]
        public void ActualizarUsuario([FromBody] Usuario usuario)
        {
            ADO_Usuario.ActualizarUsuario(usuario);

        }
        [HttpDelete("BorrarUsuario")]
        public void BorrarUsuario([FromBody] Usuario usuario)
        {
            ADO_Usuario.BorrarUsuario(usuario);

        }

    }
}
