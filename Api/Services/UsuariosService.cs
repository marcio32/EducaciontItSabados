using Api.Interfaces;
using Common.Helpers;
using Data.Dtos;
using Data.Entities;
using Data.Manager;

namespace Api.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly UsuariosManager _manager;

        public UsuariosService()
        {
            _manager = new UsuariosManager();
        }

        public async Task<List<Usuarios>> BuscarUsuariosAsync()
        {
            return await _manager.BuscarListaAsync();

        }

        public async Task<bool> GuardarUsuarioASync(UsuarioDto usuarioDto)
        {
            var usuario = new Usuarios();
            usuario = usuarioDto;
            var existe = await _manager.BuscarUsuarioAsync(usuario);
            usuario.Clave = EncryptHelper.Encriptar(usuario.Clave);
            if (existe != null && usuarioDto.Id == 0)
            {
                return false;
            }
            else
            {
                var result = await _manager.Guardar(usuario, usuario.Id);
            }
            return true;

        }

        public async Task<bool> GuardarUsuarioASync(CrearCuentaDto usuarioDto)
        {

            var usuario = new Usuarios();
            usuario = usuarioDto;
            var existe = await _manager.BuscarUsuarioAsync(usuario);
            usuario.Clave = EncryptHelper.Encriptar(usuario.Clave);
            if (existe != null)
            {
                return false;
            }
            else
            {
                var result = await _manager.Guardar(usuario, usuario.Id);
            }
            return true;

        }

        public async Task<List<Usuarios>> EliminarUsuarioASync(UsuarioDto usuarioDto)
        {

            var usuario = new Usuarios();
            usuario = usuarioDto;
            var result = await _manager.Eliminar(usuario);
            return await _manager.BuscarListaAsync();

        }
    }
}
