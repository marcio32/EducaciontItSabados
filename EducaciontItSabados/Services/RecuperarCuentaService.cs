using Api.Interfaces;
using Common.Helpers;
using Data.Dtos;
using Data.Entities;
using Data.Manager;
using EducaciontItSabados.Interfaces;

namespace Web.Services
{
    public class RecuperarCuentaService : IRecuperarCuentaService
    {
        private readonly RecuperarCuentaManager _manager;

        public RecuperarCuentaService()
        {
            _manager = new RecuperarCuentaManager();
        }
        public Usuarios BuscarUsuarios(LoginDto loginDto)
        {
            return _manager.BuscarAsync(loginDto);
        }

        public bool GuardarCodigo(UsuarioDto usuarioDto)
        {
            var usuario = new Usuarios();
            usuario = usuarioDto;
            return _manager.Guardar(usuario, usuario.Id).Result;
        }
    }
}
