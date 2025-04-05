using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationSevenSuiteTest.dto;
using WebApplicationSevenSuiteTest.model;
using WebApplicationSevenSuiteTest.model.repositories;
using WebApplicationSevenSuiteTest.util;

namespace WebApplicationSevenSuiteTest.services
{
    public class EstadoCivilServiceImpl : IEstadoCivilService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IEstadoCivilRepository repository;

        public EstadoCivilServiceImpl(IEstadoCivilRepository repository)
        {
            this.repository = repository;
        }

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
            try
            {
                IEnumerable<EstadoCivil> resultList = this.repository.Get();
                return resultList.Select(DBMapperUtil.ToDTO).ToList();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
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