using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthWeApi.Models
{
    public class UsuarioLoginRequest
    {
        public string NombreUsuario { get; set; }

        public string ClaveUsuario { get; set; }

        public string CorreoElectronico { get; set; }

        public int IdRol { get; set; }
    }
}