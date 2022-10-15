using Data.Entities;

namespace Api.Interfaces
{
    public interface IUsuariosService
    {
        Task<List<Usuarios>> BuscarUsuariosAsync();
    }
}
