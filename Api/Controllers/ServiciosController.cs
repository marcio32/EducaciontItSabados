using Api.Services;
using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServiciosController
    {
        [Authorize]
        [HttpGet]
        [Route("BuscarServicios")]
        public async Task<List<Servicios>> BuscarServicios()
        {
            var buscarServicios = new ServiciosService();
            return await buscarServicios.BuscarServiciosAsync();
        }

        [HttpPost]
        [Route("GuardarServicio")]
        public async Task<bool> GuardarServicio(ServiciosDto serviciosDto)
        {
            var guardarServicio = new ServiciosService();
            return await guardarServicio.GuardarServicioASync(serviciosDto);
        }

        [HttpPost]
        [Route("EliminarServicio")]
        public async Task<bool> EliminarServicio(ServiciosDto serviciosDto)
        {
            var guardarServicio = new ServiciosService();
            return await guardarServicio.EliminarServicioASync(serviciosDto);
        }


    }
}
