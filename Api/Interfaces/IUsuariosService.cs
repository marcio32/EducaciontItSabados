using Data.Dtos;
using Data.Entities;

namespace Api.Interfaces
{
    public interface IUsuariosService
    {
        Task<List<Usuarios>> BuscarUsuariosAsync();
        Task<bool> GuardarUsuarioASync(UsuarioDto usuario);
        Task<bool> GuardarUsuarioASync(CrearCuentaDto usuario);
        Task<List<Usuarios>> EliminarUsuarioASync(UsuarioDto usuario);
    }
}
