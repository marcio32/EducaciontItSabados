using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Servicios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public static implicit operator Servicios(ServiciosDto servicioDto)
        {
           var servicio = new Servicios();
            servicio.Id = servicioDto.Id;
            servicio.Nombre = servicioDto.Nombre;
            servicio.Activo = servicioDto.Activo;
            return servicio;
        } 
    }
}
