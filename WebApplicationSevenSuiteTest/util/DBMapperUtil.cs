
using WebApplicationSevenSuiteTest.dto;
using WebApplicationSevenSuiteTest.model;

namespace WebApplicationSevenSuiteTest.util
{
    public class DBMapperUtil
    {
        public static EstadoCivilDTO EstadoCivilToDTO(EstadoCivil entity) =>
          new EstadoCivilDTO
          {
              Id = entity.Id,
              Codigo = entity.Codigo,
              Nombre = entity.Nombre
          };

        public static EstadoCivil EstadoCivilToEntity(EstadoCivilDTO dto) =>
           new EstadoCivil
           {
               Id = dto.Id,
               Codigo = dto.Codigo,
               Nombre = dto.Nombre
           };

        public static UsuarioDTO UsuarioToDTO(Usuario entity) =>
          new UsuarioDTO
          {
              Id = entity.Id,
              Nombre = entity.Nombre,
              Clave = entity.Clave,
              Habilitado = entity.Habilitado
          };

        public static Usuario UsuarioToEntity(UsuarioDTO dto) =>
           new Usuario
           {
               Id = dto.Id,
               Nombre = dto.Nombre,
               Clave = dto.Clave,
               Habilitado = dto.Habilitado
           };

        public static SevenSuiteClienteDTO SevenSuiteClienteToDTO(SevenSuiteCliente entity) =>
          new SevenSuiteClienteDTO
          {
              Id = entity.Id,
              Cedula = entity.Cedula,
              Nombre = entity.Nombre,
              Genero = entity.Genero,
              FechaNacimiento = entity.FechaNacimiento,
              Email = entity.Email,
              EstadoCivil = entity.EstadoCivil
          };

        public static SevenSuiteCliente SevenSuiteClienteToEntity(SevenSuiteClienteDTO dto) =>
         new SevenSuiteCliente
         {
             Id = dto.Id,
             Cedula = dto.Cedula,
             Nombre = dto.Nombre,
             Genero = dto.Genero,
             FechaNacimiento = dto.FechaNacimiento,
             Email = dto.Email,
             EstadoCivil = dto.EstadoCivil
         };
    }
}