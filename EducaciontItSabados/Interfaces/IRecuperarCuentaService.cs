using Data.Dtos;
using Data.Entities;

namespace EducaciontItSabados.Interfaces
{
    public interface IRecuperarCuentaService
    {
        Usuarios BuscarUsuarios(LoginDto loginDto);
        bool GuardarCodigo(UsuarioDto usuarioDto);
    }
}
