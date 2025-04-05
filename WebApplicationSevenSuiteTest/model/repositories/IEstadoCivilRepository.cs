
using System.Collections.Generic;


namespace WebApplicationSevenSuiteTest.model.repositories
{
    /// <summary>
    /// Repositorio para entidad ESTADO_CIVIL
    /// </summary>
    public interface IEstadoCivilRepository
    {
        IEnumerable<EstadoCivil> Get();

        EstadoCivil GetById(int Id);

        int Add(EstadoCivil entity);

        int Update(EstadoCivil entity);

        void Delete(int Id);
    }
}
