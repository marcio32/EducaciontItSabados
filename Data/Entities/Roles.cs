using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Roles
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public static implicit operator Roles(RolesDto rolesDto)
        {
            var rol = new Roles();
            rol.Id = rolesDto.Id;
            rol.Nombre = rolesDto.Nombre;
            rol.Activo = rolesDto.Activo;
            return rol;
        }
    }
}
