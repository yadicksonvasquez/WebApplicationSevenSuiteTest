using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationSevenSuiteTest.model
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Clave { get; set; }

        public bool Habilitado { get; set; }
    }
}