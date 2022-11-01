using Api.Interfaces;
using Common.Helpers;
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
            try
            {
                var result = await _manager.BuscarListaAsync();
                return result;
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "RolesService", "BuscarRolesAsync");
                throw ex;
            }
        }

        public async Task<List<Roles>> GuardarRolASync(Roles rol)
        {
            try
            {
                var result = await _manager.Guardar(rol, rol.Id);
                return await _manager.BuscarListaAsync();
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "RolesService", "GuardarRolASync");
                throw ex;
            }
        }

        public async Task<List<Roles>> EliminarRolASync(Roles rol)
        {
            try
            {
                var result = await _manager.Eliminar(rol);
                return await _manager.BuscarListaAsync();
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "RolesService", "EliminarRolASync");
                throw ex;
            }

        }
    }
}
