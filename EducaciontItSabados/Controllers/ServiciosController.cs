using Data.Base;
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

        public IActionResult ServiciosAddPartial([FromBody]Servicios servicio)
        {
            var usuViewModel = new ServiciosViewModel();
            if (servicio != null)
                usuViewModel = servicio;
            return PartialView("~/Views/Servicios/Partial/ServiciosAddPartial.cshtml", usuViewModel);
        }

		public async Task<IActionResult> GuardarServicio(Servicios servicio)
		{
			var baseApi = new BaseApi(_httpClient);
            var servicios = await baseApi.PostToApi("Servicios/GuardarServicio", servicio);
            return RedirectToAction("Servicios", "Servicios");
		}

        public async Task<IActionResult> EliminarServicio([FromBody] Servicios servicio)
        {
            var baseApi = new BaseApi(_httpClient);
            servicio.Activo = false;
            var servicios = await baseApi.PostToApi("Servicios/EliminarServicio", servicio);
            return RedirectToAction("Servicios", "Servicios");
        }
    }
}
