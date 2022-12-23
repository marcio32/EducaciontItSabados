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
        public async Task<bool> GuardarUsuario(UsuarioDto usuarios)
        {
            var guardarUsuario = new UsuariosService();
            return await guardarUsuario.GuardarUsuarioASync(usuarios);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CrearCuenta")]
        public async Task<bool> CrearCuenta(CrearCuentaDto crearCuenta)
        {
            var guardarUsuario = new UsuariosService();
            return await guardarUsuario.GuardarUsuarioASync(crearCuenta);
        }

        [Authorize]
        [HttpPost]
        [Route("EliminarUsuario")]
        public async Task<List<Usuarios>> EliminarUsuario(UsuarioDto usuarios)
        {
            var guardarUsuario = new UsuariosService();
            return await guardarUsuario.EliminarUsuarioASync(usuarios);
        }


    }
}
