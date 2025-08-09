using ProyectoHotel.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ProyectoHotel.Data
{
    public class UsuariosData
    {
        public List<UsuariosModel> MtdConsultarUsuarios()
        {
            var oListaUsuarios = new List<UsuariosModel>();
            var conn = new Conexion();

            using (var CadenaConexion = new SqlConnection(conn.GetConnectionString()))
            {
                try
                {
                    CadenaConexion.Open();
                    SqlCommand cmd = new SqlCommand("usp_Usuarios_Mostrar", CadenaConexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaUsuarios.Add(new UsuariosModel
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                                Nombre = dr["Nombre"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                Rol = dr["Rol"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
            }
            return oListaUsuarios;
        } 


        public bool MtdAgregarUsuarios(UsuariosModel oUsuarios)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_Usuarios_Agregar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdEmpleado", oUsuarios.IdEmpleado);
                    cmd.Parameters.AddWithValue("@Nombre", oUsuarios.Nombre);
                    cmd.Parameters.AddWithValue("@Clave", oUsuarios.Clave); // considera hash
                    cmd.Parameters.AddWithValue("@Estado", oUsuarios.Estado);
                    cmd.Parameters.AddWithValue("@Rol", oUsuarios.Rol);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool MtdEditarUsuarios(UsuariosModel oUsuarios)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_Usuarios_Modificar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdUsuario", oUsuarios.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdEmpleado", oUsuarios.IdEmpleado);
                    cmd.Parameters.AddWithValue("@Nombre", oUsuarios.Nombre);
                    cmd.Parameters.AddWithValue("@Clave", oUsuarios.Clave); // considera hash
                    cmd.Parameters.AddWithValue("@Estado", oUsuarios.Estado);
                    cmd.Parameters.AddWithValue("@Rol", oUsuarios.Rol);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool MtdEliminarUsuarios(int IdUsuario)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_Usuarios_Eliminar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public UsuariosModel MtdBuscarUsuarios(int IdUsuario)
        {
            var oUsuario = new UsuariosModel();

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    using (var cmd = new SqlCommand("usp_Usuarios_Buscar", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oUsuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                oUsuario.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]);
                                oUsuario.Nombre = dr["Nombre"].ToString();
                                oUsuario.Clave = dr["Clave"].ToString();
                                oUsuario.Estado = dr["Estado"].ToString();
                                oUsuario.Rol = dr["Rol"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return oUsuario;
        }
    }
}
