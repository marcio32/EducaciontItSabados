﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class LoginDto
    {
        public string? Mail { get; set; }
        public string? Clave { get; set; }
        public int? Codigo { get; set; }
    }
}
