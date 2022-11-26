using Data.Dtos;
using Data.Entities;

namespace Api.Interfaces
{
	public interface IRecuperarCuentaService
	{
		public bool GuardarCodigo(Usuarios usuario);
		Usuarios BuscarUsuarios(LoginDto usuario); 
	}
}
