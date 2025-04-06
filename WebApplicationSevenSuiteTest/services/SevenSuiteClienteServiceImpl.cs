using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationSevenSuiteTest.dto;
using WebApplicationSevenSuiteTest.exceptions;
using WebApplicationSevenSuiteTest.model;
using WebApplicationSevenSuiteTest.model.repositories;
using WebApplicationSevenSuiteTest.util;

namespace WebApplicationSevenSuiteTest.services
{
    /// <summary>
    /// Implementacion del servicio ISevenSuiteClienteService
    /// </summary>
    public class SevenSuiteClienteServiceImpl : ISevenSuiteClienteService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ISevenSuiteClienteRepository repository;

        public SevenSuiteClienteServiceImpl(ISevenSuiteClienteRepository repository)
        {
            this.repository = repository;
        }

        public int Add(SevenSuiteClienteDTO dto)
        {
            try
            {
                logger.Info("[Add] Agrega un nuevo registro");
                if (String.IsNullOrEmpty(dto.Nombre) || String.IsNullOrEmpty(dto.Cedula) || String.IsNullOrEmpty(dto.Email) || String.IsNullOrEmpty(dto.EstadoCivil) || String.IsNullOrEmpty(dto.Genero) || dto.FechaNacimiento == null)
                {
                    throw new ValidationException("Campos obligatorios no ingresados");
                }
                SevenSuiteCliente entidad = DBMapperUtil.SevenSuiteClienteToEntity(dto);
                return this.repository.Add(entidad);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                logger.Info("[Delete] Borra por PK : {Id}", Id);
                if (Id == 0)
                {
                    throw new ValidationException("Id es obligatorio");
                }
                else
                {
                    return this.repository.Delete(Id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        public IEnumerable<SevenSuiteClienteDTO> Get()
        {
            try
            {
                logger.Info("[Get] Obtener todos los registros");
                IEnumerable<SevenSuiteCliente> resultList = this.repository.Get();
                return resultList.Select(DBMapperUtil.SevenSuiteClienteToDTO).ToList();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        public SevenSuiteClienteDTO GetById(int Id)
        {
            try
            {
                logger.Info("[GetById] Obtener por PK : {Id}", Id);
                if (Id == 0)
                {
                    throw new ValidationException("Id es obligatorio");
                }
                else
                {
                    SevenSuiteCliente entity = this.repository.GetById(Id);
                    return DBMapperUtil.SevenSuiteClienteToDTO(entity);
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        public int Update(SevenSuiteClienteDTO dto)
        {
            try
            {
                logger.Info("[Update] Actualizacion de registro");
                if (String.IsNullOrEmpty(dto.Nombre) || String.IsNullOrEmpty(dto.Cedula) || String.IsNullOrEmpty(dto.Email) || String.IsNullOrEmpty(dto.EstadoCivil) || String.IsNullOrEmpty(dto.Genero) || dto.FechaNacimiento == null)
                {
                    throw new ValidationException("Campos obligatorios no ingresados");
                }
                SevenSuiteCliente entidad = DBMapperUtil.SevenSuiteClienteToEntity(dto);
                return this.repository.Update(entidad);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }
    }
}