using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplicationSevenSuiteTest.dto;
using WebApplicationSevenSuiteTest.services;

namespace WebApplicationSevenSuiteTest.controllers
{
    public class UsuarioController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IUsuarioService service;

        public UsuarioController(IUsuarioService service)
        {
            this.service = service;
        }

        public IEnumerable<UsuarioDTO> Get()
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
            return new List<UsuarioDTO>();
        }

        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                logger.Info("[Get] Obteniendo por pk");
                return Request.CreateResponse<UsuarioDTO>(HttpStatusCode.OK, this.service.GetById(id));
            }
            catch (Exception e)
            {
                logger.Error(e);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public HttpResponseMessage Post([FromBody] UsuarioDTO dto)
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

        public HttpResponseMessage Put([FromBody] UsuarioDTO dto)
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


        [Route("login")]
        public HttpResponseMessage Post([FromBody] LoginDTO dto)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {
                logger.Info("[Post] Login usuario");
                if(this.service.Login(dto))
                {
                    response.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.Unauthorized;
                }
                
            }
            catch (Exception e)
            {
                logger.Error(e);
                response.StatusCode = HttpStatusCode.Unauthorized;
            }

            return response;
        }

    }
}