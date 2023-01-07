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
    public class ProductosManager : BaseManager<Productos>
    {
        public override Task<bool> Borrar(Productos producto)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Productos>> BuscarAsync(Productos producto)
        {
            throw new NotImplementedException();
        }

        public async override Task<List<Productos>> BuscarListaAsync()
        {
            return await contextSingleton.Productos.Where(x => x.Activo == true).ToListAsync();
        }
    }
}
