using Microsoft.AspNetCore.Mvc;

namespace EducaciontItSabados.Controllers
{
	public class ChatController : Controller
	{
		public IActionResult Chat(int idChat)
		{
			return View(idChat);
		}
	}
}
