using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplicationSevenSuiteTest.exceptions;
using WebApplicationSevenSuiteTest.util;

namespace WebApplicationSevenSuiteTest.model.repositories
{
    public class SevenSuiteClienteRepositoryImpl : ISevenSuiteClienteRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public int Add(SevenSuiteCliente entity)
        {
            string sqlDML = "INSERT INTO SEVECLIE (cedula, nombre, genero, fecha_nac, email, estado_civil) VALUES (@dni, @name, @gender, @datebirth, @email, @maritalstatus)";
            try
            {
                using (SqlConnection con = new SqlConnection(DatabaseUtil.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlDML, con))
                    {
                        command.Parameters.AddWithValue("@dni", entity.Cedula);
                        command.Parameters.AddWithValue("@name", entity.Nombre);
                        command.Parameters.AddWithValue("@gender", entity.Genero);
                        command.Parameters.AddWithValue("@datebirth", entity.FechaNacimiento);
                        command.Parameters.AddWithValue("@email", entity.Email);
                        command.Parameters.AddWithValue("@maritalstatus", entity.EstadoCivil);
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        public bool Delete(int Id)
        {
            string sqlDML = "Delete from SEVECLIE where id=@recordId";
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
                throw;
            }
        }

        public IEnumerable<SevenSuiteCliente> Get()
        {
            List<SevenSuiteCliente> entityList = new List<SevenSuiteCliente>();
            string sqlQuery = String.Format("select * from SEVECLIE");

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
                                SevenSuiteCliente customer = new SevenSuiteCliente();
                                customer.Id = Convert.ToInt32(dataReader["id"]);
                                customer.Cedula = dataReader["cedula"].ToString();
                                customer.Nombre = dataReader["nombre"].ToString();
                                customer.Genero = dataReader["genero"].ToString();
                                customer.FechaNacimiento = Convert.ToDateTime(dataReader["fecha_nac"]);
                                customer.Email = dataReader["email"].ToString();
                                customer.EstadoCivil = dataReader["estado_civil"].ToString();
                                entityList.Add(customer);
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }

            return entityList;
        }

        public SevenSuiteCliente GetById(int Id)
        {
            SevenSuiteCliente customer = new SevenSuiteCliente();
            string sqlQuery = String.Format("select * from SEVECLIE where id=@recordId");
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
                                customer.Id = Convert.ToInt32(dataReader["id"]);
                                customer.Cedula = dataReader["cedula"].ToString();
                                customer.Nombre = dataReader["nombre"].ToString();
                                customer.Genero = dataReader["genero"].ToString();
                                customer.FechaNacimiento = Convert.ToDateTime(dataReader["fecha_nac"]);
                                customer.Email = dataReader["email"].ToString();
                                customer.EstadoCivil = dataReader["estado_civil"].ToString();
                            }
                        }
                        else
                        {
                            throw new NotFoundException("Cliente no encontrado ID: " + Id);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
            return customer;
        }

        public int Update(SevenSuiteCliente entity)
        {
            string sqlDML = "Update SEVECLIE SET cedula=@dni, nombre=@name, genero=@gender, fecha_nac=@datebirth, email=@email, estado_civil=@maritalstatus  where id=@recordId";
            try
            {
                using (SqlConnection con = new SqlConnection(DatabaseUtil.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlDML, con))
                    {
                        command.Parameters.AddWithValue("@dni", entity.Cedula);
                        command.Parameters.AddWithValue("@name", entity.Nombre);
                        command.Parameters.AddWithValue("@gender", entity.Genero);
                        command.Parameters.AddWithValue("@datebirth", entity.FechaNacimiento);
                        command.Parameters.AddWithValue("@email", entity.Email);
                        command.Parameters.AddWithValue("@maritalstatus", entity.EstadoCivil);
                        command.Parameters.AddWithValue("@recordId", entity.Id);
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        public SevenSuiteCliente GetByCedula(string cedula)
        {
            SevenSuiteCliente customer = null;
            string sqlQuery = String.Format("select * from SEVECLIE where cedula=@recordCedula");
            try
            {
                using (SqlConnection con = new SqlConnection(DatabaseUtil.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, con))
                    {
                        command.Parameters.AddWithValue("@recordCedula", cedula);
                        SqlDataReader dataReader = command.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            if (dataReader.Read())
                            {
                                customer = new SevenSuiteCliente();
                                customer.Id = Convert.ToInt32(dataReader["id"]);
                                customer.Cedula = dataReader["cedula"].ToString();
                                customer.Nombre = dataReader["nombre"].ToString();
                                customer.Genero = dataReader["genero"].ToString();
                                customer.FechaNacimiento = Convert.ToDateTime(dataReader["fecha_nac"]);
                                customer.Email = dataReader["email"].ToString();
                                customer.EstadoCivil = dataReader["estado_civil"].ToString();
                            }
                        }
                        else
                        {
                            throw new NotFoundException("Cliente no encontrado ID: " + cedula);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);               
            }
            return customer;
        }
    }
}