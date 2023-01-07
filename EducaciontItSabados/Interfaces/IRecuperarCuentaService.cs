using Data.Dtos;
using Data.Entities;

namespace EducaciontItSabados.Interfaces
{
    public interface IRecuperarCuentaService
    {
        Task<Usuarios?> BuscarUsuarios(LoginDto loginDto);
        bool GuardarCodigo(UsuariosDto usuarioDto);
    }
}
