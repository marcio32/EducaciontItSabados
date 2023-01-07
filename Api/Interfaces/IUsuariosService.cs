using Data.Dtos;
using Data.Entities;

namespace Api.Interfaces
{
    public interface IUsuariosService
    {
        Task<List<Usuarios>> BuscarUsuariosAsync();
        Task<bool> GuardarUsuarioASync(UsuariosDto usuarioDto);
        Task<bool> GuardarUsuarioASync(CrearCuentaDto crearCuentaDto);
        Task<bool> EliminarUsuarioASync(UsuariosDto usuarioDto);
    }
}
