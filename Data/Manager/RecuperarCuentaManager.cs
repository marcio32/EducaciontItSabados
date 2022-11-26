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
	public class RecuperarCuentaManager : BaseManager<Usuarios>
	{


        public Usuarios BuscarAsync(LoginDto usuario)
        {

			if(usuario.Clave != null)
			{
                return contextSingleton.Usuarios.Where(x => x.Codigo == usuario.Codigo).FirstOrDefault();
			}
			else
			{
                return contextSingleton.Usuarios.Where(x => x.Mail == usuario.Mail).FirstOrDefault();
            }

        }

        public override Task<List<Usuarios>> Borrar(Usuarios usuario)
		{
			throw new NotImplementedException();
		}

		public override Task<List<Usuarios>> BuscarAsync(Usuarios entity)
		{
			throw new NotImplementedException();
		}

		public override Task<List<Usuarios>> BuscarListaAsync()
		{
			throw new NotImplementedException();
		}
	}
}
