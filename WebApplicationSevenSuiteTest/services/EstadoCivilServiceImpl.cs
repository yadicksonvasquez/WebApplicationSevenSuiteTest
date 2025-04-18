﻿using NLog;
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
    /// Implementacion del servicio IEstadoCivilService
    /// </summary>
    public class EstadoCivilServiceImpl : IEstadoCivilService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IEstadoCivilRepository repository;

        public EstadoCivilServiceImpl(IEstadoCivilRepository repository)
        {
            this.repository = repository;
        }

        public int Add(EstadoCivilDTO dto)
        {
            try
            {
                logger.Info("[Add] Agrega un nuevo registro");
                if (String.IsNullOrEmpty(dto.Nombre) || String.IsNullOrEmpty(dto.Codigo))
                {
                    throw new ValidationException("Campos obligatorios no ingresados");
                }
                EstadoCivil entidad = DBMapperUtil.EstadoCivilToEntity(dto);
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

        public IEnumerable<EstadoCivilDTO> Get()
        {
            try
            {
                logger.Info("[Get] Obtener todos los registros");
                IEnumerable<EstadoCivil> resultList = this.repository.Get();
                return resultList.Select(DBMapperUtil.EstadoCivilToDTO).ToList();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        public EstadoCivilDTO GetById(int Id)
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
                    EstadoCivil entity = this.repository.GetById(Id);
                    return DBMapperUtil.EstadoCivilToDTO(entity);
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        public int Update(EstadoCivilDTO dto)
        {
            try
            {
                logger.Info("[Update] Actualizacion de registro");
                if (String.IsNullOrEmpty(dto.Nombre) || String.IsNullOrEmpty(dto.Codigo))
                {
                    throw new ValidationException("Campos obligatorios no ingresados");
                }
                EstadoCivil entidad = DBMapperUtil.EstadoCivilToEntity(dto);
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