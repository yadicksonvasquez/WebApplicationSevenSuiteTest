
using System.Collections.Generic;
using WebApplicationSevenSuiteTest.dto;

namespace WebApplicationSevenSuiteTest.services
{
    public interface IEstadoCivilService
    {
        /// <summary>
        /// Obtiene todos los registros
        /// </summary>
        /// <returns></returns>
        IEnumerable<EstadoCivilDTO> Get();

        /// <summary>
        /// Obtiene el registro por PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        EstadoCivilDTO GetById(int Id);

        /// <summary>
        /// Agrega un nuevo registro
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        int Add(EstadoCivilDTO dto);

        /// <summary>
        /// Actualiza un registro
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        int Update(EstadoCivilDTO dto);

        /// <summary>
        /// Borra un registro por PK
        /// </summary>
        /// <param name="Id"></param>
        bool Delete(int Id);
    }
}
