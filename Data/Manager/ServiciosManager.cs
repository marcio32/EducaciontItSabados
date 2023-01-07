using Data.Base;
using Data.Dtos;
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
        public bool Borrar(ServiciosDto servicio)
        {
            return contextSingleton.Database.ExecuteSqlRaw($"EliminarServicio {servicio.Id}") > 0;
        }

        public override Task<List<Servicios>> BuscarAsync(Servicios servicio)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GuardarAsync (ServiciosDto servicio)
        {
            return contextSingleton.Database.ExecuteSqlRaw($"GuardaroActualizarServicios {servicio.Id}, {servicio.Nombre}, {servicio.Activo}") > 0;
        }

        public async override Task<List<Servicios>> BuscarListaAsync()
        {
            return contextSingleton.Servicios.FromSqlRaw("ObtenerServicios").ToList();
        }

        public override Task<bool> Borrar(Servicios entity)
        {
            throw new NotImplementedException();
        }
    }
}
