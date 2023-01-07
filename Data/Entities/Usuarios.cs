using Data.Dtos;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Clave { get; set; }
        public string Mail { get; set; }
        [ForeignKey("Roles")]
        public int Id_Rol { get; set; }
        public bool Activo { get; set; }
        public int? Codigo { get; set; }
        public Roles? Roles { get; set; }

        public static implicit operator Usuarios(CrearCuentaDto crearCuenta)
        {
            var usuario = new Usuarios();
            usuario.Nombre = crearCuenta.Nombre;
            usuario.Apellido = crearCuenta.Apellido;
            usuario.Fecha_Nacimiento = crearCuenta.Fecha_Nacimiento;
            usuario.Clave = crearCuenta.Clave;
            usuario.Mail = crearCuenta.Mail;
            usuario.Id_Rol = crearCuenta.Id_Rol;
            usuario.Activo = crearCuenta.Activo;
            return usuario;
        }

        public static implicit operator Usuarios(UsuariosDto usuarioDto)
        {
            var usuario = new Usuarios();
            usuario.Id = usuarioDto.Id;
            usuario.Nombre = usuarioDto.Nombre;
            usuario.Apellido = usuarioDto.Apellido;
            usuario.Fecha_Nacimiento = usuarioDto.Fecha_Nacimiento;
            usuario.Clave = usuarioDto.Clave;
            usuario.Mail = usuarioDto.Mail;
            usuario.Id_Rol = usuarioDto.Id_Rol;
            usuario.Activo = usuarioDto.Activo;
            return usuario;
        }
    }
}
