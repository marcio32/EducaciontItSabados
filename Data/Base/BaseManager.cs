using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Base
{
    public abstract class BaseManager<T> where T : class
    {
        #region Singleton Context
        private static ApplicationDbContext contextInstance = null;

        public static ApplicationDbContext contextSingleton
        {
            get
            {
                if (contextInstance == null)
                    contextInstance = new ApplicationDbContext();
                return contextInstance;

            }
        }
        #endregion

        #region Metodos Abstractos
        public abstract Task<List<T>> BuscarListaAsync();
        public abstract Task<List<T>> BuscarAsync(T entity);
        public abstract Task<List<T>> Borrar(T entity);
        #endregion

        #region Metodos Publicos
        public async Task<bool> Guardar(T entity, int id)
        {
            try
            {
                if (id == 0)
                    contextSingleton.Entry(entity).State = EntityState.Added;
                else
                    contextSingleton.Entry(entity).State = EntityState.Modified;

                var resultado = await contextSingleton.SaveChangesAsync() > 0;
                return resultado;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Eliminar(T entity)
        {
            try
            {

                contextSingleton.Entry(entity).State = EntityState.Modified;

                var resultado = await contextSingleton.SaveChangesAsync() > 0;
                return resultado;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
