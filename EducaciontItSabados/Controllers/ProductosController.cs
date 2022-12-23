using Data.Base;
using Data.Dtos;
using Data.Entities;
using EducaciontItSabados.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducaciontItSabados.Contproductolers
{
	public class ProductosController : Controller
	{
        private readonly IHttpClientFactory _httpClient;
        public ProductosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [Authorize]
        public IActionResult Productos()
		{
			return View();
		}

        public IActionResult ProductosAddPartial([FromBody] ProductosDto productoDto)
        {
            var usuViewModel = new ProductosViewModel();
            if (productoDto != null)
                usuViewModel = productoDto;
            return PartialView("~/Views/Productos/Partial/ProductosAddPartial.cshtml", usuViewModel);
        }

		public async Task<IActionResult> GuardarProducto(ProductosDto productoDto)
		{

            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            if(productoDto.Imagen_Archivo != null && productoDto.Imagen_Archivo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    productoDto.Imagen_Archivo.CopyTo(ms);
                    var imagenBytes = ms.ToArray();
                    productoDto.Imagen = Convert.ToBase64String(imagenBytes);
                }
            }
            productoDto.Imagen_Archivo = null;
            var productos = await baseApi.PostToApi("Productos/GuardarProducto", productoDto, token);
            return RedirectToAction("Productos", "Productos");
		}

        public async Task<IActionResult> EliminarProducto([FromBody] ProductosDto productoDto)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            productoDto.Activo = false;
            var productos = await baseApi.PostToApi("Productos/EliminarProducto", productoDto, token);
            return RedirectToAction("Productos", "Productos");
        }
    }
}
