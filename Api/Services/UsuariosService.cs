using Api.Interfaces;
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
            try
            {
                var result = await _manager.BuscarListaAsync();
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Usuarios>> GuardarUsuarioASync(Usuarios usuario)
        {
            var result = await _manager.Guardar(usuario, usuario.Id);
            return await _manager.BuscarListaAsync();
        }

        public async Task<List<Usuarios>> EliminarUsuarioASync(Usuarios usuario)
        {
            var result = await _manager.Eliminar(usuario);
            return await _manager.BuscarListaAsync();
        }
    }
}
