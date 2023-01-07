using Data.Dtos;
using Data.Entities;

namespace EducaciontItSabados.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuarios> BuscarUsuario(LoginDto loginDto);
    }
}
