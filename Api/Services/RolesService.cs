using Api.Interfaces;
using Common.Helpers;
using Data.Dtos;
using Data.Entities;
using Data.Manager;

namespace Api.Services
{
    public class RolesService : IRolesService
    {
        private readonly RolesManager _manager;

        public RolesService()
        {
            _manager = new RolesManager();
        }

        public async Task<List<Roles>> BuscarRolesAsync()
        {
            return await _manager.BuscarListaAsync();
        }

        public async Task<bool> GuardarRolASync(RolesDto rolDto)
        {

            var rol = new Roles();
            rol = rolDto;
            return await _manager.Guardar(rol, rol.Id);
        }

        public async Task<bool> EliminarRolASync(RolesDto rolDto)
        {
            var rol = new Roles();
            rol = rolDto;
            return await _manager.Eliminar(rol);

        }
    }
}
