using Api.Services;
using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
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

        [Authorize]
        [HttpPost]
        [Route("GuardarUsuario")]
        public async Task<bool> GuardarUsuario(UsuariosDto usuariosDto)
        {
            var guardarUsuario = new UsuariosService();
            return await guardarUsuario.GuardarUsuarioASync(usuariosDto);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CrearCuenta")]
        public async Task<bool> CrearCuenta(CrearCuentaDto crearCuentaDto)
        {
            var guardarUsuario = new UsuariosService();
            return await guardarUsuario.GuardarUsuarioASync(crearCuentaDto);
        }

        [Authorize]
        [HttpPost]
        [Route("EliminarUsuario")]
        public async Task<bool> EliminarUsuario(UsuariosDto usuariosDto)
        {
            var guardarUsuario = new UsuariosService();
            return await guardarUsuario.EliminarUsuarioASync(usuariosDto);
        }


    }
}
