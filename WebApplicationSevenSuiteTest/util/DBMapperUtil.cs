
using WebApplicationSevenSuiteTest.dto;
using WebApplicationSevenSuiteTest.model;

namespace WebApplicationSevenSuiteTest.util
{
    public class DBMapperUtil
    {
        public static EstadoCivilDTO ToDTO(EstadoCivil entity) =>
          new EstadoCivilDTO
          {
              Id = entity.Id,
              Codigo = entity.Codigo,
              Nombre = entity.Nombre
          };

        public static EstadoCivil ToEntity(EstadoCivilDTO dto) =>
           new EstadoCivil
           {
               Id = dto.Id,
               Codigo = dto.Codigo,
               Nombre = dto.Nombre
           };
    }
}