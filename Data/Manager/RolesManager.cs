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
    public class RolesManager : BaseManager<Roles>
    {
        public override Task<bool> Borrar(Roles rol)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Roles>> BuscarAsync(Roles rol)
        {
            throw new NotImplementedException();
        }

        public async override Task<List<Roles>> BuscarListaAsync()
        {
            return await contextSingleton.Roles.Where(x => x.Activo == true).ToListAsync();
        }
    }
}
