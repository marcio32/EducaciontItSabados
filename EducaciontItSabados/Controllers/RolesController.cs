using Data.Base;
using Data.Dtos;
using Data.Entities;
using EducaciontItSabados.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Roles()
		{
			return View();
		}

        public IActionResult RolesAddPartial([FromBody]RolesDto rolDto)
        {
            var usuViewModel = new RolesViewModel();
            if (rolDto != null)
                usuViewModel = rolDto;
            return PartialView("~/Views/Roles/Partial/RolesAddPartial.cshtml", usuViewModel);
        }

		public async Task<IActionResult> GuardarRol(RolesDto rolDto)
		{
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var roles = await baseApi.PostToApi("Roles/GuardarRol", rolDto, token);
            return RedirectToAction("Roles", "Roles");
		}

        public async Task<IActionResult> EliminarRol([FromBody] RolesDto rolDto)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            rolDto.Activo = false;
            var roles = await baseApi.PostToApi("Roles/EliminarRol", rolDto, token);
            return RedirectToAction("Roles", "Roles");
        }
    }
}
