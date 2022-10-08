using Microsoft.AspNetCore.Mvc;

namespace EducaciontItSabados.Controllers
{
	public class UsuariosController : Controller
	{
		public IActionResult Usuarios()
		{
			return View();
		}
	}
}
