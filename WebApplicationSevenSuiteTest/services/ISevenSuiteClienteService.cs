using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationSevenSuiteTest.dto;

namespace WebApplicationSevenSuiteTest.services
{
    public interface ISevenSuiteClienteService
    {
        /// <summary>
        /// Obtiene todos los registros
        /// </summary>
        /// <returns></returns>
        IEnumerable<SevenSuiteClienteDTO> Get();

        /// <summary>
        /// Obtiene el registro por PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        SevenSuiteClienteDTO GetById(int Id);

        /// <summary>
        /// Agrega un nuevo registro
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        int Add(SevenSuiteClienteDTO dto);

        /// <summary>
        /// Actualiza un registro
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        int Update(SevenSuiteClienteDTO dto);

        /// <summary>
        /// Borra un registro por PK
        /// </summary>
        /// <param name="Id"></param>
        bool Delete(int Id);
    }
}
