using Data.Base;
using Data.Dtos;
using Data.Entities;
using EducaciontItSabados.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducaciontItSabados.Controllers
{
	public class ServiciosController : Controller
	{
        private readonly IHttpClientFactory _httpClient;
        public ServiciosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [Authorize]
        public IActionResult Servicios()
		{
			return View();
		}

        public IActionResult ServiciosAddPartial([FromBody]ServiciosDto servicioDto)
        {
            var usuViewModel = new ServiciosViewModel();
            if (servicioDto != null)
                usuViewModel = servicioDto;
            return PartialView("~/Views/Servicios/Partial/ServiciosAddPartial.cshtml", usuViewModel);
        }

		public async Task<IActionResult> GuardarServicio(ServiciosDto servicioDto)
		{
			var baseApi = new BaseApi(_httpClient);
            var token = HttpContext.Session.GetString("Token");
            var servicios = await baseApi.PostToApi("Servicios/GuardarServicio", servicioDto, token);
            return RedirectToAction("Servicios", "Servicios");
		}

        public async Task<IActionResult> EliminarServicio([FromBody] ServiciosDto servicioDto)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            servicioDto.Activo = false;
            var servicios = await baseApi.PostToApi("Servicios/EliminarServicio", servicioDto, token);
            return RedirectToAction("Servicios", "Servicios");
        }
    }
}
