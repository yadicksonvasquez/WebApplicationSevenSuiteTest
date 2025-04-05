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
    /// Implementacion del servicio IUsuarioService
    /// </summary>
    public class UsuarioServiceImpl : IUsuarioService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IUsuarioRepository repository;

        public UsuarioServiceImpl(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        public int Add(UsuarioDTO dto)
        {
            try
            {
                logger.Info("[Add] Agrega un nuevo registro");
                if (String.IsNullOrEmpty(dto.Nombre) || String.IsNullOrEmpty(dto.Clave))
                {
                    throw new ValidationException("Campos obligatorios no ingresados");
                }
                Usuario entidad = DBMapperUtil.UsuarioToEntity(dto);
                entidad.Clave = CryptographyUtil.EncryptPassword(dto.Clave);
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

        public IEnumerable<UsuarioDTO> Get()
        {
            try
            {
                logger.Info("[Get] Obtener todos los registros");
                IEnumerable<Usuario> resultList = this.repository.Get();
                return resultList.Select(DBMapperUtil.UsuarioToDTO).ToList();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        public UsuarioDTO GetById(int Id)
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
                    Usuario entity = this.repository.GetById(Id);
                    return DBMapperUtil.UsuarioToDTO(entity);
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        public int Update(UsuarioDTO dto)
        {
            try
            {
                logger.Info("[Update] Actualizacion de registro");
                if (String.IsNullOrEmpty(dto.Nombre) || String.IsNullOrEmpty(dto.Clave))
                {
                    throw new ValidationException("Campos obligatorios no ingresados");
                }
                Usuario entidad = DBMapperUtil.UsuarioToEntity(dto);
                entidad.Clave = CryptographyUtil.EncryptPassword(dto.Clave);
                return this.repository.Update(entidad);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }


        public bool Login(LoginDTO dto)
        {
            try
            {
                if (String.IsNullOrEmpty(dto.Usuario) || String.IsNullOrEmpty(dto.Clave))
                {
                    throw new ValidationException("Campos obligatorios no ingresados");
                }
                Usuario user = this.repository.GetByUsername(dto.Usuario);
                return dto.Clave.Equals(CryptographyUtil.DecryptPassword(user.Clave));
            }
            catch (Exception e)
            {
                logger.Error(e);
            }

            return false;
        }
    }
}