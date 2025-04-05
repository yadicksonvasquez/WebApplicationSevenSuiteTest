using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplicationSevenSuiteTest.util;

namespace WebApplicationSevenSuiteTest.model.repositories
{
    /// <summary>
    /// Implementacion IUsuarioRepository
    /// </summary>
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public int Add(Usuario entity)
        {
            string sqlDML = "INSERT INTO USUARIO (nombre, clave, habilitado) VALUES (@name, @password, @enable)";
            try
            {
                using (SqlConnection con = new SqlConnection(DatabaseUtil.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlDML, con))
                    {
                        command.Parameters.AddWithValue("@name", entity.Nombre);
                        command.Parameters.AddWithValue("@password", entity.Clave);
                        command.Parameters.AddWithValue("@enable", entity.Habilitado);
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
            string sqlDML = "Delete from USUARIO where id=@recordId";
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

        public IEnumerable<Usuario> Get()
        {
            List<Usuario> entityList = new List<Usuario>();
            string sqlQuery = String.Format("select * from USUARIO");

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
                                Usuario user = new Usuario();
                                user.Id = Convert.ToInt32(dataReader["id"]);
                                user.Nombre = dataReader["nombre"].ToString();
                                user.Clave = dataReader["clave"].ToString();
                                user.Habilitado = Convert.ToBoolean(dataReader["habilitado"]);
                                entityList.Add(user);
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

        public Usuario GetById(int Id)
        {
            Usuario user = new Usuario();
            string sqlQuery = String.Format("select * from USUARIO where id=@recordId");
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
                                user.Id = Convert.ToInt32(dataReader["id"]);
                                user.Nombre = dataReader["nombre"].ToString();
                                user.Clave = dataReader["clave"].ToString();
                                user.Habilitado = Convert.ToBoolean(dataReader["habilitado"]);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return user;
        }

        public int Update(Usuario entity)
        {
            string sqlDML = "Update USUARIO SET nombre=@name, clave=@password,  where id=@recordId";
            try
            {
                using (SqlConnection con = new SqlConnection(DatabaseUtil.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlDML, con))
                    {
                        command.Parameters.AddWithValue("@name", entity.Nombre);
                        command.Parameters.AddWithValue("@password", entity.Clave);
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