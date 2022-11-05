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
        public override Task<List<Servicios>> Borrar(Servicios entity)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Servicios>> BuscarAsync(Servicios entity)
        {
            throw new NotImplementedException();
        }

        public async override Task<List<Servicios>> BuscarListaAsync()
        {
            return await contextSingleton.Servicios.Where(x => x.Activo == true).ToListAsync();
        }
    }
}
