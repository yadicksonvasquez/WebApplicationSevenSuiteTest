
using System.Collections.Generic;


namespace WebApplicationSevenSuiteTest.model.repositories
{
    /// <summary>
    /// Repositorio para entidad USUARIO
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Obtiene todos los registros disponibles en base de datos
        /// </summary>
        /// <returns></returns>
        IEnumerable<Usuario> Get();

        /// <summary>
        /// Obtiene el registro filtrando por PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Usuario GetById(int Id);

        /// <summary>
        /// Agrega un nuevo registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(Usuario entity);

        /// <summary>
        /// Actualiza un registro existente
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(Usuario entity);

        /// <summary>
        /// Borra un registro por PK
        /// </summary>
        /// <param name="Id"></param>
        bool Delete(int Id);

        /// <summary>
        /// Busca el usuario por el campo name
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Usuario</returns>
        Usuario GetByUsername(string username);
    }
}
