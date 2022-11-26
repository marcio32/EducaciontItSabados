using Api.Interfaces;
using Common.Helpers;
using Data.Dtos;
using Data.Entities;
using Data.Manager;

namespace Api.Services
{
	public class RecuperarCuentaService : IRecuperarCuentaService
	{
		private readonly RecuperarCuentaManager _manager;

		public RecuperarCuentaService()
		{
			_manager = new RecuperarCuentaManager();
		}
		public Usuarios BuscarUsuarios(LoginDto usuario)
		{
			try
			{
                var usuarios = _manager.BuscarAsync(usuario);
                return usuarios;
            }
			catch(Exception ex)
			{
                GenerateLogHelper.LogError(ex, "RecuperarCuentaService", "BuscarUsuarios");
                throw ex;
            }
        }

		public bool GuardarCodigo(Usuarios usuario)
		{
			try
			{
				var resultado = _manager.Guardar(usuario, usuario.Id);
				return resultado.Result;
			}
			catch(Exception ex)
			{
                GenerateLogHelper.LogError(ex, "RecuperarCuentaService", "GuardarCodigo");
                throw ex;
            }
		}
	}
}
