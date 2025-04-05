using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplicationSevenSuiteTest.util;

namespace WebApplicationSevenSuiteTest.model.repositories
{
    /// <summary>
    /// Implementacion IEstadoCivilRepository
    /// </summary>
    public class EstadoCivilRepositoryImpl : IEstadoCivilRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public int Add(EstadoCivil entity)
        {
            string sqlDML = "INSERT INTO ESTADO_CIVIL (codigo, nombre) VALUES (@code, @name)"; 
            try
            {
                using (SqlConnection con = new SqlConnection(DatabaseUtil.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlDML, con))
                    {
                        command.Parameters.AddWithValue("@code", entity.Codigo);
                        command.Parameters.AddWithValue("@name", entity.Nombre);
                        return command.ExecuteNonQuery();
                    }                    
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return 0;
        }

        public bool Delete(int Id)
        {
            string sqlDML = "Delete from ESTADO_CIVIL where id=@recordId";
            try
            {
                using (SqlConnection con = new SqlConnection(DatabaseUtil.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlDML, con))
                    {
                        command.Parameters.AddWithValue("@recordId", Id);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return false;
        }

        public IEnumerable<EstadoCivil> Get()
        {
            List<EstadoCivil> entityList = new List<EstadoCivil>();
            string sqlQuery = String.Format("select * from ESTADO_CIVIL");

            try
            {
                using (SqlConnection con = new SqlConnection(DatabaseUtil.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        con.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                EstadoCivil maritalStatus = new EstadoCivil();
                                maritalStatus.Id = Convert.ToInt32(dataReader["id"]);
                                maritalStatus.Codigo = dataReader["codigo"].ToString();
                                maritalStatus.Nombre = dataReader["nombre"].ToString();
                                entityList.Add(maritalStatus);
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }

            return entityList;
        }

        public EstadoCivil GetById(int Id)
        {
            EstadoCivil maritalStatus = new EstadoCivil();
            string sqlQuery = String.Format("select * from ESTADO_CIVIL where id=@recordId");
            try
            {
                using (SqlConnection con = new SqlConnection(DatabaseUtil.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, con))
                    {
                        command.Parameters.AddWithValue("@recordId", Id);
                        SqlDataReader dataReader = command.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            if (dataReader.Read())
                            {
                                maritalStatus.Id = Convert.ToInt32(dataReader["id"]);
                                maritalStatus.Codigo = dataReader["codigo"].ToString();
                                maritalStatus.Nombre = dataReader["nombre"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return maritalStatus;
        }

        public int Update(EstadoCivil entity)
        {
            string sqlDML = "Update ESTADO_CIVIL SET codigo=@code, nombre=@name where id=@recordId";
            try
            {
                using (SqlConnection con = new SqlConnection(DatabaseUtil.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlDML, con))
                    {
                        command.Parameters.AddWithValue("@code", entity.Codigo);
                        command.Parameters.AddWithValue("@name", entity.Nombre);
                        command.Parameters.AddWithValue("@recordId", entity.Id);
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return 0;
        }
    }
}