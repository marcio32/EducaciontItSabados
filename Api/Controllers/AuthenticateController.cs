﻿using Api.Services;
using Common.Helpers;
using Data;
using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {

        private static ApplicationDbContext contextInstance;
        private readonly IConfiguration _configuration;

        public AuthenticateController(IConfiguration configuration)
        {
            contextInstance = new ApplicationDbContext();
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            loginDto.Clave = EncryptHelper.Encriptar(loginDto.Clave);
            var validarUsuario = contextInstance.Usuarios.Where(x => x.Mail == loginDto.Mail && x.Clave == loginDto.Clave).Include(x => x.Roles).FirstOrDefault();

            if (validarUsuario != null)
            {
                var Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, validarUsuario.Mail),
                    new Claim(ClaimTypes.DateOfBirth, validarUsuario.Fecha_Nacimiento.ToString()),
                    new Claim(ClaimTypes.Role, validarUsuario.Roles.Nombre),
                };

                var token = CrearToken(Claims);
                return Ok(new JwtSecurityTokenHandler().WriteToken(token).ToString() + ";" + validarUsuario.Nombre + ";" + validarUsuario.Roles.Nombre + ";" + validarUsuario.Mail);
            }
            else
            {
                return Unauthorized();
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string LoginGoogle(LoginDto loginDto)
        {
            var validarUsuario = contextInstance.Usuarios.Where(x => x.Mail == loginDto.Mail).Include(x => x.Roles).FirstOrDefault();

            if (validarUsuario != null)
            {
                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, validarUsuario.Mail),
                    new Claim(ClaimTypes.DateOfBirth, validarUsuario.Fecha_Nacimiento.ToString()),
                    new Claim(ClaimTypes.Role, validarUsuario.Roles.Nombre),
                };

                var token = CrearToken(claim);
                return new JwtSecurityTokenHandler().WriteToken(token).ToString() + ";" + validarUsuario.Nombre + ";" + validarUsuario.Roles.Nombre + ";" + validarUsuario.Mail;
            }
            else
            {
                return "";
            }
        }


        private JwtSecurityToken CrearToken(List<Claim> claim)
        {
            var firma = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Firma"]));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(24),
                claims: claim,
                signingCredentials: new SigningCredentials(firma, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
