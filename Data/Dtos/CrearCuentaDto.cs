using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class CrearCuentaDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Clave { get; set; }
        public string Mail { get; set; }
        public int Id_Rol { get { return 2; } }
        public bool Activo { get { return true; } }

    }
}
