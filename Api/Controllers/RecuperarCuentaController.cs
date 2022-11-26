using Api.Services;
using Common.Helpers;
using Data;
using Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RecuperarCuentaController : Controller
	{
		private readonly IConfiguration _configuration;
		private static ApplicationDbContext context;

		public RecuperarCuentaController(IConfiguration configuration)
		{
			context = new ApplicationDbContext();
			_configuration = configuration;

        }

		[HttpPost]
		[Route("GuardarCodigo")]
		public bool GuardarCodigo(LoginDto login)
		{
			try
			{
				var recuperarCuenta = new RecuperarCuentaService();
				var usuario = recuperarCuenta.BuscarUsuarios(login);
				if(usuario != null)
				{
                    usuario.Codigo = login.Codigo;
                    return recuperarCuenta.GuardarCodigo(usuario);
				}
				else
				{
					return false;
				}
				

            }
			catch (Exception ex)
			{
                GenerateLogHelper.LogError(ex, "RecuperarCuentaController", "GuardarCodigo");
                throw ex;
            }
		}

		[HttpPost]
		[Route("CambiarClave")]
		public bool CambiarClave(LoginDto login)
		{
			try
			{
				var recuperarCuenta = new RecuperarCuentaService();
				var usuario = recuperarCuenta.BuscarUsuarios(login);
				if(usuario != null)
				{
					usuario.Codigo = null;
					usuario.Clave = EncryptHelper.Encriptar(login.Clave);
					return recuperarCuenta.GuardarCodigo(usuario);
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
                GenerateLogHelper.LogError(ex, "RecuperarCuentaController", "CambiarClave");
                throw ex;
            }
		}
	}
}
