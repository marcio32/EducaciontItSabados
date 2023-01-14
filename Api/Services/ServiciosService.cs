using Api.Interfaces;
using Common.Helpers;
using Data.Dtos;
using Data.Entities;
using Data.Manager;

namespace Api.Services
{
    public class ServiciosService : IServiciosService
    {
        private readonly ServiciosManager _manager;

        public ServiciosService()
        {
            _manager = new ServiciosManager();
        }

        public async Task<List<Servicios>> BuscarServiciosAsync()
        {
            return await _manager.BuscarListaAsync();
        }

        public async Task<bool> GuardarServicioASync(ServiciosDto servicioDto)
        {
            if (BuscarServiciosAsync().Result.Where(x => x.Nombre == servicioDto.Nombre && x.Activo == true).ToList().Count > 0)
            {
                return false;
            }
            else {
                return await _manager.GuardarAsync(servicioDto);
            }
           
        }

        public bool EliminarServicioASync(ServiciosDto servicioDto)
        {
            return _manager.Borrar(servicioDto);
        }
    }
}
