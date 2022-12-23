using Data.Base;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Data.Dtos;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Net.Mail;
using System.Net;
using EducaciontItSabados.ViewModels;
using Microsoft.AspNetCore.Authentication.Google;
using EducaciontItSabados.Services;
using Api.Controllers;
using Web.Services;
using Common.Helpers;
using Microsoft.Extensions.Configuration;

namespace EducaciontItSabados.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;
        public LoginController(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _smtpClient = new SmtpClient();
        }

        public IActionResult OlvidoClave()
        {
            return View();
        }

        public IActionResult RecuperarCuenta()
        {
            return View();
        }

        public IActionResult CrearCuenta()
        {
            return View();
        }

        public async Task<ActionResult> LoginAsync()
        {
            if (TempData["ErrorLogin"] != null)
                ViewBag.ErrorLogin = TempData["ErrorLogin"].ToString();
            return View();
        }

        public async Task<IActionResult> Ingresar(LoginDto login)
        {
            var baseApi = new BaseApi(_httpClient);
            var token = await baseApi.PostToApi("Authenticate/Login", login, "");
            var resultadoLogin = token as OkObjectResult;

            if (resultadoLogin != null)
            {
                var resultadoSplit = resultadoLogin.Value.ToString().Split(";");
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                Claim claimNombre = new(ClaimTypes.Name, resultadoSplit[1]);
                Claim claimRole = new(ClaimTypes.Role, resultadoSplit[2]);
                Claim claimEmail = new(ClaimTypes.Email, resultadoSplit[3]);

                identity.AddClaim(claimNombre);
                identity.AddClaim(claimRole);
                identity.AddClaim(claimEmail);

                ClaimsPrincipal usuarioPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, usuarioPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddDays(1)
                });
                ViewBag.NombreUsuario = resultadoSplit[1];

                HttpContext.Session.SetString("Token", resultadoSplit[0]);

                var homeViewModel = new HomeViewModel();
                homeViewModel.Token = resultadoSplit[0];
                return View("~/Views/Home/Index.cshtml", homeViewModel);
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

        public async Task<IActionResult> EnviarMail(LoginDto login)
        {
            var guid = Guid.NewGuid();
            var numeros = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(numeros.Substring(0, 6));
            var random = new Random(seed);
            var codigo = random.Next(000000, 999999);

            login.Codigo = codigo;

            var recuperarCuenta = new RecuperarCuentaService();
            var usuario = recuperarCuenta.BuscarUsuarios(login);
            var resultadoLogin = false;
            if (usuario != null)
            {
                usuario.Codigo = login.Codigo;
                resultadoLogin = recuperarCuenta.GuardarCodigo(usuario);
            }

            if (resultadoLogin != null && resultadoLogin == true)
            {
                MailMessage mail = new();

                string CuerpoMail = CuerpoMailLogin(codigo);

                mail.From = new MailAddress(_configuration["ConfiguracionMail:Usuario"]);
                mail.To.Add(login.Mail);
                mail.Subject = "Codigo Recuperacion";
                mail.Body = CuerpoMail;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;

                _smtpClient.Host = _configuration["ConfiguracionMail:DireccionServidor"];
                _smtpClient.Port = int.Parse(_configuration["ConfiguracionMail:Puerto"]);
                _smtpClient.EnableSsl = bool.Parse(_configuration["ConfiguracionMail:Ssl"]);
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential(_configuration["ConfiguracionMail:Usuario"], _configuration["ConfiguracionMail:Clave"]);

                _smtpClient.Send(mail);
                return RedirectToAction("RecuperarCuenta", "Login");
            }
            else
            {
                TempData["ErrorLogin"] = "El mail que intenta recuperar no existe";
                return RedirectToAction("Login", "Login");
            }
        }

        private static string CuerpoMailLogin(int codigo)
        {
            string separacion = "<br>";
            var mensaje = "<strong>A continuacion se mostrara un codigo que debera ingresar en la web de Educacion IT</strong>";
            mensaje += $" <strong>{codigo}</strong> {separacion}";
            return mensaje;
        }

        public async Task<IActionResult> CambiarClave(LoginDto loginDto)
        {


            var recuperarCuenta = new RecuperarCuentaService();
            var usuario = recuperarCuenta.BuscarUsuarios(loginDto);
            var resultadoLogin = false;
            if (usuario != null)
            {
                var usuarioDto = new UsuarioDto();
                usuarioDto = usuario;
                usuarioDto.Codigo = null;
                usuarioDto.Clave = EncryptHelper.Encriptar(loginDto.Clave);
                resultadoLogin = recuperarCuenta.GuardarCodigo(usuarioDto);
            }

            if (resultadoLogin != null && resultadoLogin == true)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                TempData["ErrorLogin"] = "El codigo ingresado no coincide con el enviado al mail";
                return RedirectToAction("Login", "Login");
            }
        }

        public async Task<IActionResult> CrearUsuarioLogin(CrearCuentaDto usuario)
        {
            var baseApi = new BaseApi(_httpClient);
            var response = await baseApi.PostToApi("Usuarios/CrearCuenta", usuario);
            var resultadoLogin = response as OkObjectResult;
            if (resultadoLogin != null && resultadoLogin.Value.ToString() == "true")
            {
                TempData["ErrorLogin"] = "Se creo el usuario correctamente";
                return RedirectToAction("Login", "Login");
            }
            else
            {
                TempData["ErrorLogin"] = "No se pudo crear el usuario. Contacte a sistemas";
                return RedirectToAction("Login", "Login");
            }
        }

        public async Task LoginGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var resultado = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = resultado.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Value,
                claim.Type,
                claim.Issuer,
                claim.OriginalIssuer
            });
            var login = new LoginDto();
            login.Mail = claims.ToList()[4].Value;

            var usuarioServicio = new UsuarioService();
            var usuario = usuarioServicio.BuscarUsuario(login).Result;

            if (usuario != null)
            {
                var authenticate = new AuthenticateController(_configuration);

                var token = authenticate.LoginGoogle(login);

                var resultadoSplit = token.ToString().Split(";");
                ViewBag.NombreUsuario = resultadoSplit[1];
                HttpContext.Session.SetString("Token", resultadoSplit[0]);
                var homeViewModel = new HomeViewModel();
                homeViewModel.Token = resultadoSplit[0];
                return View("~/Views/Home/Index.cshtml", homeViewModel);

            }
            else
            {
                TempData["ErrorLogin"] = "El usuario no existe";
                return RedirectToAction("Login", "Login");
            }
        }

    }
}
