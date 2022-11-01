using Data.Entities;

namespace Api.Interfaces
{
    public interface IRolesService
    {
        Task<List<Roles>> BuscarRolesAsync();
        Task<List<Roles>> GuardarRolASync(Roles rol);
        Task<List<Roles>> EliminarRolASync(Roles rol);
    }
}
