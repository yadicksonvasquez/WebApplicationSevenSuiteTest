
using System.Collections.Generic;


namespace WebApplicationSevenSuiteTest.model.repositories
{
    /// <summary>
    /// Repositorio para entidad ESTADO_CIVIL
    /// </summary>
    public interface IEstadoCivilRepository
    {
        /// <summary>
        /// Obtiene todos los registros disponibles en base de datos
        /// </summary>
        /// <returns></returns>
        IEnumerable<EstadoCivil> Get();

        /// <summary>
        /// Obtiene el registro filtrando por PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        EstadoCivil GetById(int Id);

        /// <summary>
        /// Agrega un nuevo registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(EstadoCivil entity);

        /// <summary>
        /// Actualiza un registro existente
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(EstadoCivil entity);

        /// <summary>
        /// Borra un registro por PK
        /// </summary>
        /// <param name="Id"></param>
        bool Delete(int Id);
    }
}
