using Data.Dtos;
using Data.Entities;
using Data.Manager;
using EducaciontItSabados.Interfaces;

namespace EducaciontItSabados.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly UsuariosManager _manager;

		public UsuarioService()
		{
			_manager = new UsuariosManager();
		}
		public async Task<Usuarios> BuscarUsuario(LoginDto usuario)
		{
            return await _manager.BuscarUsuarioGoogleAsync(usuario);
		}
	}
}
