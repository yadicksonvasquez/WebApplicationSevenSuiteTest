using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationSevenSuiteTest.dto
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Clave { get; set; }

        public bool Habilitado { get; set; }
    }
}