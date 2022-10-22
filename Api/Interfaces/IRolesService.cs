using Data.Entities;

namespace Api.Interfaces
{
    public interface IRolesService
    {
        Task<List<Roles>> BuscarRolesAsync();
    }
}
