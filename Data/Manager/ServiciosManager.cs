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
        public async override Task<List<Servicios>> Borrar(Servicios servicio)
        {
            contextSingleton.Database.ExecuteSqlRaw($"EliminarServicio {servicio.Id}");
            return contextSingleton.Servicios.FromSqlRaw("ObtenerServicios").ToList();
        }

        public override Task<List<Servicios>> BuscarAsync(Servicios entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Servicios>> GuardarAsync (Servicios servicio)
        {
            var p = contextSingleton.Database.ExecuteSqlRaw($"GuardaroActualizarServicios {servicio.Id}, {servicio.Nombre}, {servicio.Activo}");
            return contextSingleton.Servicios.FromSqlRaw("ObtenerServicios").ToList();
        }

        public async override Task<List<Servicios>> BuscarListaAsync()
        {
            return contextSingleton.Servicios.FromSqlRaw("ObtenerServicios").ToList();
        }

    }
}
