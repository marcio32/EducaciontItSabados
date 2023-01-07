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
        public async Task<Usuarios?> BuscarAsync(LoginDto loginDto)
        {
			if(loginDto.Clave != null)
			{
                return await contextSingleton.Usuarios.FirstOrDefaultAsync(x => x.Codigo == loginDto.Codigo);
			}
			else
			{
                return await contextSingleton.Usuarios.FirstOrDefaultAsync(x => x.Mail == loginDto.Mail);
            }
        }

        public override Task<bool> Borrar(Usuarios usuario)
		{
			throw new NotImplementedException();
		}

		public override Task<List<Usuarios>> BuscarAsync(Usuarios usuario)
		{
			throw new NotImplementedException();
		}

		public override Task<List<Usuarios>> BuscarListaAsync()
		{
			throw new NotImplementedException();
		}
	}
}
