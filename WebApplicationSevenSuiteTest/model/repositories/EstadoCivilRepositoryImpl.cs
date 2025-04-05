using NLog;
using System;
using System.Collections.Generic;


namespace WebApplicationSevenSuiteTest.model.repositories
{
    public class EstadoCivilRepositoryImpl : IEstadoCivilRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public int Add(EstadoCivil entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstadoCivil> Get()
        {
            throw new NotImplementedException();
        }

        public EstadoCivil GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(EstadoCivil entity)
        {
            throw new NotImplementedException();
        }
    }
}