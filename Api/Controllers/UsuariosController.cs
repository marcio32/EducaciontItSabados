using Api.Services;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController
    {
        [Authorize]
        [HttpGet]
        [Route("BuscarUsuarios")]
        public async Task<List<Usuarios>> BuscarUsuarios()
        {
            var buscarUsuarios = new UsuariosService();
            return await buscarUsuarios.BuscarUsuariosAsync();
        }

        [HttpPost]
        [Route("GuardarUsuario")]
        public async Task<List<Usuarios>> GuardarUsuario(Usuarios usuarios)
        {
            var guardarUsuario = new UsuariosService();
            return await guardarUsuario.GuardarUsuarioASync(usuarios);
        }

        [HttpPost]
        [Route("EliminarUsuario")]
        public async Task<List<Usuarios>> EliminarUsuario(Usuarios usuarios)
        {
            var guardarUsuario = new UsuariosService();
            return await guardarUsuario.EliminarUsuarioASync(usuarios);
        }


    }
}
