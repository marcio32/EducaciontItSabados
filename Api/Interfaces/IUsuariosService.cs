using Data.Entities;

namespace Api.Interfaces
{
    public interface IUsuariosService
    {
        Task<List<Usuarios>> BuscarUsuariosAsync();
        Task<List<Usuarios>> GuardarUsuarioASync(Usuarios usuario);
        Task<List<Usuarios>> EliminarUsuarioASync(Usuarios usuario);
    }
}
