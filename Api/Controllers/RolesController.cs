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
    public class RolesController
    {

        [HttpGet]
        [Route("BuscarRoles")]
        public async Task<List<Roles>> BuscarRoles()
        {
            var buscarRoles = new RolesService();
            return await buscarRoles.BuscarRolesAsync();
        }

        [HttpPost]
        [Route("GuardarRol")]
        public async Task<bool> GuardarRol(RolesDto rolesDto)
        {
            var guardarRol = new RolesService();
            return await guardarRol.GuardarRolASync(rolesDto);
        }

        [HttpPost]
        [Route("EliminarRol")]
        public async Task<bool> EliminarRol(RolesDto rolesDto)
        {
            var guardarRol = new RolesService();
            return await guardarRol.EliminarRolASync(rolesDto);
        }


    }
}
