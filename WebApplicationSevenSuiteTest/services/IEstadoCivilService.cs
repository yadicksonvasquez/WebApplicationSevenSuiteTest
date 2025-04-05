
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
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(EstadoCivilDTO entity);

        /// <summary>
        /// Actualiza un registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(EstadoCivilDTO entity);

        /// <summary>
        /// Borra un registro por PK
        /// </summary>
        /// <param name="Id"></param>
        void Delete(int Id);
    }
}
