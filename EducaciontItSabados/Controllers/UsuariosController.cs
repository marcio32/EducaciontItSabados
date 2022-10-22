using Data.Base;
using Data.Entities;
using EducaciontItSabados.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EducaciontItSabados.Controllers
{
	public class UsuariosController : Controller
	{
        private readonly IHttpClientFactory _httpClient;
        public UsuariosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Usuarios()
		{
			return View();
		}

        public IActionResult UsuariosAddPartial([FromBody]Usuarios usuario)
        {
            var usuViewModel = new UsuariosViewModel();
            if (usuario != null)
                usuViewModel = usuario;
            return PartialView("~/Views/Usuarios/Partial/UsuariosAddPartial.cshtml", usuViewModel);
        }

		public async Task<IActionResult> GuardarUsuario(Usuarios usuario)
		{
			var baseApi = new BaseApi(_httpClient);
            var usuarios = await baseApi.PostToApi("Usuarios/GuardarUsuario", usuario);
            return RedirectToAction("Usuarios", "Usuarios");
		}

        public async Task<IActionResult> EliminarUsuario([FromBody] Usuarios usuario)
        {
            var baseApi = new BaseApi(_httpClient);
            usuario.Activo = false;
            var usuarios = await baseApi.PostToApi("Usuarios/EliminarUsuario", usuario);
            return RedirectToAction("Usuarios", "Usuarios");
        }
    }
}
