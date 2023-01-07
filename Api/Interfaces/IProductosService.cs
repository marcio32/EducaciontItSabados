using Data.Dtos;
using Data.Entities;

namespace Api.Interfaces
{
    public interface IProductosService
    {
        Task<List<Productos>> BuscarProductosAsync();
        Task<bool> GuardarProductoASync(ProductosDto productoDto);
        Task<bool> EliminarProductoASync(ProductosDto productoDto);
    }
}
