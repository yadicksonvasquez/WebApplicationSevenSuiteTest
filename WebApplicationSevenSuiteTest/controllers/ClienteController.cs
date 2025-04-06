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
    public class ClienteController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ISevenSuiteClienteService service;

        public ClienteController(ISevenSuiteClienteService service)
        {
            this.service = service;
        }

        [Route("api/v1/cliente")]
        [HttpGet]
        public IEnumerable<SevenSuiteClienteDTO> Get()
        {
            try
            {
                logger.Info("[Get] Obteniendo todos los registros");
                return this.service.Get();
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return new List<SevenSuiteClienteDTO>();
        }


        [Route("api/v1/cliente/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                logger.Info("[Get] Obteniendo por pk");
                return Request.CreateResponse<SevenSuiteClienteDTO>(HttpStatusCode.OK, this.service.GetById(id));
            }
            catch (Exception e)
            {
                logger.Error(e);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }


        [Route("api/v1/cliente")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] SevenSuiteClienteDTO dto)
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
            }
            catch (Exception e)
            {
                logger.Error(e);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        [Route("api/v1/cliente")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody] SevenSuiteClienteDTO dto)
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
            }
            catch (Exception e)
            {
                logger.Error(e);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        [Route("api/v1/cliente/{id}")]
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
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

    }
}