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

        public async Task<bool> GuardarUsuarioASync(UsuariosDto usuarioDto)
        {
            if (await _manager.BuscarUsuarioAsync(usuarioDto) != null && usuarioDto.Id == 0)
            {
                return false;
            }
            else
            {
                var usuario = new Usuarios();
                usuario = usuarioDto;
                usuario.Clave = EncryptHelper.Encriptar(usuario.Clave);
                return await _manager.Guardar(usuario, usuario.Id);
            }
        }

        public async Task<bool> GuardarUsuarioASync(CrearCuentaDto crearCuentaDto)
        {
            if (await _manager.BuscarUsuarioAsync(crearCuentaDto) != null)
            {
                return false;
            }
            else
            {
                var usuario = new Usuarios();
                usuario = crearCuentaDto;
                usuario.Clave = EncryptHelper.Encriptar(usuario.Clave);
                return await _manager.Guardar(usuario, usuario.Id);
            }
        }

        public async Task<bool> EliminarUsuarioASync(UsuariosDto usuarioDto)
        {
            var usuario = new Usuarios();
            usuario = usuarioDto;
            return await _manager.Eliminar(usuario);
        }
    }
}
