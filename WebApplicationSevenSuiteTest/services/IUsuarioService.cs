using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationSevenSuiteTest.dto;

namespace WebApplicationSevenSuiteTest.services
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Obtiene todos los registros
        /// </summary>
        /// <returns></returns>
        IEnumerable<UsuarioDTO> Get();

        /// <summary>
        /// Obtiene el registro por PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        UsuarioDTO GetById(int Id);

        /// <summary>
        /// Agrega un nuevo registro
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        int Add(UsuarioDTO dto);

        /// <summary>
        /// Actualiza un registro
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        int Update(UsuarioDTO dto);

        /// <summary>
        /// Borra un registro por PK
        /// </summary>
        /// <param name="Id"></param>
        bool Delete(int Id);
    }
}
