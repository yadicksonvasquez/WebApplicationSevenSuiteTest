using NLog;
using System;
using System.Collections.Generic;
using WebApplicationSevenSuiteTest.dto;

namespace WebApplicationSevenSuiteTest.services
{
    public class EstadoCivilServiceImpl : IEstadoCivilService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public int Add(EstadoCivilDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstadoCivilDTO> Get()
        {
            throw new NotImplementedException();
        }

        public EstadoCivilDTO GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(EstadoCivilDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}