using Data.Entities;

namespace Api.Interfaces
{
    public interface IProductosService
    {
        Task<List<Productos>> BuscarProductosAsync();
        Task<List<Productos>> GuardarProductoASync(Productos producto);
        Task<List<Productos>> EliminarProductoASync(Productos producto);
    }
}
