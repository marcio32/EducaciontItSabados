using Common.Helpers;
using Data.Base;
using Data.Entities;
using EducaciontItSabados.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

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

        public async Task<IActionResult> UsuariosAddPartial([FromBody] Usuarios usuario)
        {
            var usuViewModel = new UsuariosViewModel();
            var baseApi = new BaseApi(_httpClient);
            var roles = await baseApi.GetToApi("Roles/BuscarRoles");
            var resultadoRoles = roles as OkObjectResult;

            if (usuario != null)
            {
                usuario.Clave = EncryptHelper.Desencriptar(usuario.Clave);
                usuViewModel = usuario;
               
            }
                

            if (resultadoRoles != null)
            {
                var listaRoles = JsonConvert.DeserializeObject<List<Roles>>(resultadoRoles.Value.ToString());
                var listaItemsRoles = new List<SelectListItem>();
                foreach (var list in listaRoles)
                {
                    listaItemsRoles.Add(new SelectListItem { Text = list.Nombre, Value = list.Id.ToString() });
                }
                usuViewModel.Lista_Roles = listaItemsRoles;
            }

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
