using Data.Dtos;
using Data.Entities;

namespace Api.Interfaces
{
    public interface IServiciosService
    {
        Task<List<Servicios>> BuscarServiciosAsync();
        Task<bool> GuardarServicioASync(ServiciosDto servicioDto);
        bool EliminarServicioASync(ServiciosDto servicioDto);
    }
}
