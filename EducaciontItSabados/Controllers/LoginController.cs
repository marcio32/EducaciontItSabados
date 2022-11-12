using Data.Base;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Data.Dtos;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace EducaciontItSabados.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public LoginController(IHttpClientFactory
            httpClient)
        {
            _httpClient = httpClient;
        }
        // GET: LoginController
        public async Task<ActionResult> LoginAsync()
        {
            if (TempData["ErrorLogin"] != null)
                ViewBag.ErrorLogin = TempData["ErrorLogin"].ToString();
            return View();
        }

        public async Task<IActionResult> Ingresar(LoginDto login)
        {
            var baseApi = new BaseApi(_httpClient);
            var token = await baseApi.PostToApi("Authenticate/Login", login);
            var resultadoLogin = token as OkObjectResult;

            if (resultadoLogin != null)
            {
                var resultadoSplit = resultadoLogin.Value.ToString().Split(";");
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                Claim claimNombre = new(ClaimTypes.Name, resultadoSplit[0]);
                Claim claimRole = new(ClaimTypes.Role, resultadoSplit[1]);
                Claim claimEmail = new(ClaimTypes.Email, resultadoSplit[2]);

                identity.AddClaim(claimNombre);
                identity.AddClaim(claimRole);
                identity.AddClaim(claimEmail);

                ClaimsPrincipal usuarioPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, usuarioPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddDays(1)
                });

                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                TempData["ErrorLogin"] = "La contraseña o el mail no coinciden";
                return RedirectToAction("Login", "Login");
            }
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }

    }
}
