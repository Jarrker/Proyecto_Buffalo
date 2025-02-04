﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Empleado
    {
        public int IdUsuario { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public CE_Rol oRol { get; set; }
        public bool Estado { get; set; }

        public bool IsLoggedIn { get; set; }
        public string FechaRegistro { get; set; }
    }
}
