using Api.Interfaces;
using Common.Helpers;
using Data.Dtos;
using Data.Entities;
using Data.Manager;

namespace Api.Services
{
    public class ProductosService : IProductosService
    {
        private readonly ProductosManager _manager;

        public ProductosService()
        {
            _manager = new ProductosManager();
        }

        public async Task<List<Productos>> BuscarProductosAsync()
        {
            return await _manager.BuscarListaAsync();
        }

        public async Task<bool> GuardarProductoASync(ProductosDto productoDto)
        {
            var producto = new Productos();
            producto = productoDto;
            return await _manager.Guardar(producto, producto.Id);
        }

        public async Task<bool> EliminarProductoASync(ProductosDto productoDto)
        {
            var producto = new Productos();
            producto = productoDto;
            return await _manager.Eliminar(producto);

        }
    }
}
