using Api.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiciosController
    {

        [HttpGet]
        [Route("BuscarServicios")]
        public async Task<List<Servicios>> BuscarServicios()
        {
            var buscarServicios = new ServiciosService();
            return await buscarServicios.BuscarServiciosAsync();
        }

        [HttpPost]
        [Route("GuardarServicio")]
        public async Task<List<Servicios>> GuardarServicio(Servicios servicios)
        {
            var guardarServicio = new ServiciosService();
            return await guardarServicio.GuardarServicioASync(servicios);
        }

        [HttpPost]
        [Route("EliminarServicio")]
        public async Task<List<Servicios>> EliminarServicio(Servicios servicios)
        {
            var guardarServicio = new ServiciosService();
            return await guardarServicio.EliminarServicioASync(servicios);
        }


    }
}
