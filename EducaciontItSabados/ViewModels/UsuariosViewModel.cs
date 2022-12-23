using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducaciontItSabados.ViewModels
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Clave { get; set; }
        public string Mail { get; set; }
        public int Id_Rol { get; set; }
        public bool Activo { get; set; }
        public int Codigo { get; set; }
        public IEnumerable<SelectListItem> Lista_Roles { get; set; }

        public static implicit operator UsuariosViewModel(UsuarioDto usuario)
        {
            var usuViewModel = new UsuariosViewModel();
            usuViewModel.Id = usuario.Id;
            usuViewModel.Nombre = usuario.Nombre;
            usuViewModel.Apellido = usuario.Apellido;
            usuViewModel.Mail = usuario.Mail;
            usuViewModel.Fecha_Nacimiento = usuario.Fecha_Nacimiento;
            usuViewModel.Id_Rol = usuario.Id_Rol;
            usuViewModel.Clave = usuario.Clave;
            usuViewModel.Activo = usuario.Activo;
            return usuViewModel;
             
        }
    }


}
