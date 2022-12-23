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
            var servicio = new Servicios();
            servicio = servicioDto;
            return await _manager.GuardarAsync(servicio);
        }

        public async Task<bool> EliminarServicioASync(ServiciosDto servicioDto)
        {
            var servicio = new Servicios();
            servicio = servicioDto;
            return await _manager.Borrar(servicio);
        }
    }
}
