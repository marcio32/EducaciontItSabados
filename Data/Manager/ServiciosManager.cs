using Data.Base;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Manager
{
    public class ServiciosManager : BaseManager<Servicios>
    {
        public async override Task<bool> Borrar(Servicios servicio)
        {
            var respuesta = contextSingleton.Database.ExecuteSqlRaw($"EliminarServicio {servicio.Id}");
            return respuesta == 1 ? true : false;
        }

        public override Task<List<Servicios>> BuscarAsync(Servicios entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GuardarAsync (Servicios servicio)
        {
            var respuesta = contextSingleton.Database.ExecuteSqlRaw($"GuardaroActualizarServicios {servicio.Id}, {servicio.Nombre}, {servicio.Activo}");
            return respuesta == 1 ? true : false;
        }

        public async override Task<List<Servicios>> BuscarListaAsync()
        {
            return contextSingleton.Servicios.FromSqlRaw("ObtenerServicios").ToList();
        }

    }
}
