using Api.Services;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController
    {

        [HttpGet]
        [Route("BuscarProductos")]
        public async Task<List<Productos>> BuscarProductos()
        {
            var buscarProductos = new ProductosService();
            return await buscarProductos.BuscarProductosAsync();
        }

        [HttpPost]
        [Route("GuardarProducto")]
        public async Task<List<Productos>> GuardarProducto(Productos productos)
        {
            var guardarProducto = new ProductosService();
            return await guardarProducto.GuardarProductoASync(productos);
        }

        [HttpPost]
        [Route("EliminarProducto")]
        public async Task<List<Productos>> EliminarProducto(Productos productos)
        {
            var guardarProducto = new ProductosService();
            return await guardarProducto.EliminarProductoASync(productos);
        }


    }
}
