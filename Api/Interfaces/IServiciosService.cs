using Data.Entities;

namespace Api.Interfaces
{
    public interface IServiciosService
    {
        Task<List<Servicios>> BuscarServiciosAsync();
        Task<List<Servicios>> GuardarServicioASync(Servicios servicio);
        Task<List<Servicios>> EliminarServicioASync(Servicios servicio);
    }
}
