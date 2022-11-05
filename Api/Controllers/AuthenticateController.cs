using Api.Services;
using Common.Helpers;
using Data;
using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {

        private static ApplicationDbContext contextInstance;

        public AuthenticateController()
        {
            contextInstance = new ApplicationDbContext();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto usuario)
        {
            usuario.Clave = EncryptHelper.Encriptar(usuario.Clave);
            var validarUsuario = contextInstance.Usuarios.Where(x => x.Mail == usuario.Mail && x.Clave == usuario.Clave).FirstOrDefault();

            if(validarUsuario != null)
            {
                return Ok("true");
            }
            else
            {
                return Ok("false");
            }
        }

    }
}
