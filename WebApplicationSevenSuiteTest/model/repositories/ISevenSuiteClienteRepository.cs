
using System.Collections.Generic;


namespace WebApplicationSevenSuiteTest.model.repositories
{
    public interface ISevenSuiteClienteRepository
    {
        /// <summary>
        /// Obtiene todos los registros disponibles en base de datos
        /// </summary>
        /// <returns></returns>
        IEnumerable<SevenSuiteCliente> Get();

        /// <summary>
        /// Obtiene el registro filtrando por PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        SevenSuiteCliente GetById(int Id);

        /// <summary>
        /// Agrega un nuevo registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(SevenSuiteCliente entity);

        /// <summary>
        /// Actualiza un registro existente
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(SevenSuiteCliente entity);

        /// <summary>
        /// Borra un registro por PK
        /// </summary>
        /// <param name="Id"></param>
        bool Delete(int Id);
    }
}
