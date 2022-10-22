using Data.Base;
using Data.Entities;
using EducaciontItSabados.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EducaciontItSabados.Controllers
{
	public class RolesController : Controller
	{
        private readonly IHttpClientFactory _httpClient;
        public RolesController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Roles()
		{
			return View();
		}

        public IActionResult RolesAddPartial([FromBody]Roles rol)
        {
            var usuViewModel = new RolesViewModel();
            if (rol != null)
                usuViewModel = rol;
            return PartialView("~/Views/Roles/Partial/RolesAddPartial.cshtml", usuViewModel);
        }

		public async Task<IActionResult> GuardarRol(Roles rol)
		{
			var baseApi = new BaseApi(_httpClient);
            var roles = await baseApi.PostToApi("Roles/GuardarRol", rol);
            return RedirectToAction("Roles", "Roles");
		}

        public async Task<IActionResult> EliminarRol([FromBody] Roles rol)
        {
            var baseApi = new BaseApi(_httpClient);
            rol.Activo = false;
            var roles = await baseApi.PostToApi("Roles/EliminarRol", rol);
            return RedirectToAction("Roles", "Roles");
        }
    }
}
