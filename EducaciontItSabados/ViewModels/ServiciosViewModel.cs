using Data.Entities;

namespace EducaciontItSabados.ViewModels
{
    public class ServiciosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public static implicit operator ServiciosViewModel(Servicios servicio)
        {
            var servicioViewModel = new ServiciosViewModel();
            servicioViewModel.Id = servicio.Id;
            servicioViewModel.Nombre = servicio.Nombre;
            servicioViewModel.Activo = servicio.Activo;
            return servicioViewModel;

        }
    }


}
