using Common.Helpers;
using Data.Base;
using Data.Dtos;
using Data.Entities;
using EducaciontItSabados.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Usuarios()
        {
            return View();
        }

        public async Task<IActionResult> UsuariosAddPartial([FromBody] UsuariosDto usuarioDto)
        {
            var token = HttpContext.Session.GetString("Token");
            var usuViewModel = new UsuariosViewModel();
            var baseApi = new BaseApi(_httpClient);
            var roles = await baseApi.GetToApi("Roles/BuscarRoles", token);
            var resultadoRoles = roles as OkObjectResult;

            if (usuarioDto != null)
            {
                usuarioDto.Clave = EncryptHelper.Desencriptar(usuarioDto.Clave);
                usuViewModel = usuarioDto;
               
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

        public async Task<IActionResult> GuardarUsuario(UsuariosDto usuarioDto)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var usuarios = await baseApi.PostToApi("Usuarios/GuardarUsuario", usuarioDto, token);
            return RedirectToAction("Usuarios", "Usuarios");
        }

        public async Task<IActionResult> EliminarUsuario([FromBody] UsuariosDto usuarioDto)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            usuarioDto.Activo = false;
            var usuarios = await baseApi.PostToApi("Usuarios/EliminarUsuario", usuarioDto, token);
            return RedirectToAction("Usuarios", "Usuarios");
        }
    }
}
