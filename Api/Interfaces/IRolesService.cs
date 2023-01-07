using Data.Dtos;
using Data.Entities;

namespace Api.Interfaces
{
    public interface IRolesService
    {
        Task<List<Roles>> BuscarRolesAsync();
        Task<bool> GuardarRolASync(RolesDto rolDto);
        Task<bool> EliminarRolASync(RolesDto rolDto);
    }
}
