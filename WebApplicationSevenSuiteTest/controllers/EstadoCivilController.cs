using NLog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationSevenSuiteTest.dto;
using WebApplicationSevenSuiteTest.services;

namespace WebApplicationSevenSuiteTest.controllers
{
    public class EstadoCivilController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IEstadoCivilService service;

        public EstadoCivilController(IEstadoCivilService service)
        {
            this.service = service;
        }

        public IEnumerable<EstadoCivilDTO> Get()
        {
            try
            {
                logger.Info("[Get] Obteniendo todos los estados civiles");
                return this.service.Get();
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return new List<EstadoCivilDTO>();
        }

        public EstadoCivilDTO Get(int id)
        {
            try
            {
                logger.Info("[Get] Obteniendo por pk");
                return this.service.GetById(Id);
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return "value";
        }

        public HttpResponseMessage Post([FromBody] EstadoCivilDTO dto)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                logger.Info("[Post] Agregar un nuevo registro");
                int result = this.service.Add(dto);
                if (result > 0)
                {
                    return response;
                }
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return response;
        }

        public HttpResponseMessage Put([FromBody] EstadoCivilDTO dto)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                logger.Info("[Put] Actualizar registro");
                int result = this.service.Update(dto);
                if (result > 0)
                {
                    return response;
                }
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                logger.Info("[Delete] Borrar registro");
                if (this.service.Delete(Id))
                {
                    return response;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.InternalServerError;
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return response;
        }
    }
}