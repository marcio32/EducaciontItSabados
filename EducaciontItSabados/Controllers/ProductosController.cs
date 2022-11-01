using Data.Base;
using Data.Entities;
using EducaciontItSabados.ViewModels;
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
        public IActionResult Productos()
		{
			return View();
		}

        public IActionResult ProductosAddPartial([FromBody]Productos producto)
        {
            var usuViewModel = new ProductosViewModel();
            if (producto != null)
                usuViewModel = producto;
            return PartialView("~/Views/Productos/Partial/ProductosAddPartial.cshtml", usuViewModel);
        }

		public async Task<IActionResult> GuardarProducto(Productos producto)
		{
			var baseApi = new BaseApi(_httpClient);
            if(producto.Imagen_Archivo != null && producto.Imagen_Archivo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    producto.Imagen_Archivo.CopyTo(ms);
                    var imagenBytes = ms.ToArray();
                    producto.Imagen = Convert.ToBase64String(imagenBytes);
                }
            }
            producto.Imagen_Archivo = null;
            var productos = await baseApi.PostToApi("Productos/GuardarProducto", producto);
            return RedirectToAction("Productos", "Productos");
		}

        public async Task<IActionResult> EliminarProducto([FromBody] Productos producto)
        {
            var baseApi = new BaseApi(_httpClient);
            producto.Activo = false;
            var productos = await baseApi.PostToApi("Productos/EliminarProducto", producto);
            return RedirectToAction("Productos", "Productos");
        }
    }
}
