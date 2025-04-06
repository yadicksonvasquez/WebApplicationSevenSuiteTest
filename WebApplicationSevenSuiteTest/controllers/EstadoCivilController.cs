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

        [Route("api/v1/estadocivil")]
        [HttpGet]
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

        [Route("api/v1/estadocivil/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                logger.Info("[Get] Obteniendo por pk");
                return Request.CreateResponse<EstadoCivilDTO>(HttpStatusCode.OK, this.service.GetById(id));
            }
            catch (Exception e)
            {
                logger.Error(e);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        [Route("api/v1/estadocivil")]
        [HttpPost]
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

        [Route("api/v1/estadocivil")]
        [HttpPut]
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

        [Route("api/v1/estadocivil/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                logger.Info("[Delete] Borrar registro");
                if (this.service.Delete(id))
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