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
    }
}
