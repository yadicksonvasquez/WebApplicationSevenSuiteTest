using System;


namespace WebApplicationSevenSuiteTest.dto
{
    public class SevenSuiteClienteDTO
    {
        public int Id { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Genero { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Email { get; set; }

        public string EstadoCivil { get; set; }
    }
}