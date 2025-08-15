using ProyectoHotel.Models;
using Microsoft.Data.SqlClient;
using System.Data;


namespace ProyectoHotel.Data
{
    public class ServiciosData
    {
        // Metodo que consulta datos
        public List<ServiciosModel> MtdConsultarServicios() //1. CambiarelNombre
        {
            var oListaServicios = new List<ServiciosModel>(); //2. CambiarNombre
            var conn = new Conexion();

            using (var CadenaConexion = new SqlConnection(conn.GetConnectionString()))
            {
                try
                {
                    CadenaConexion.Open();
                    SqlCommand cmd = new SqlCommand("usp_servicios_mostrar", CadenaConexion) //Cambiar nombre usp 
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaServicios.Add(new ServiciosModel //3
                            {
                                IdServicio = Convert.ToInt32(dr["IdServicio"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                TipoServicio = dr["TipoServicio"].ToString(),
                                Precio = Convert.ToDouble(dr["Precio"]),
                                Estado = dr["Estado"].ToString(),
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return oListaServicios;
        }


        // Metodo que agrega datos
        public bool MtdAgregarServicios(ServiciosModel oServicios)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_servicios_crear", sqlConnection);
                    cmd.Parameters.AddWithValue("@Descripcion", oServicios.Descripcion);
                    cmd.Parameters.AddWithValue("@TipoServicio", oServicios.TipoServicio);
                    cmd.Parameters.AddWithValue("@Precio", oServicios.Precio);
                    cmd.Parameters.AddWithValue("@Estado", oServicios.Estado);
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


        // Metodo que actualiza datos
        public bool MtdEditarServicios(ServiciosModel oServicios)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_servicios_actualizar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdServicio", oServicios.IdServicio);
                    cmd.Parameters.AddWithValue("@Descripcion", oServicios.Descripcion);
                    cmd.Parameters.AddWithValue("@TipoServicio", oServicios.TipoServicio);
                    cmd.Parameters.AddWithValue("@Precio", oServicios.Precio);
                    cmd.Parameters.AddWithValue("@Estado", oServicios.Estado);
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

        // Método que busca un dato por su código
        public ServiciosModel MtdBuscarServicios(int IdServicio)
        {
            var oServicios = new ServiciosModel();

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    using (var cmd = new SqlCommand("usp_servicios_buscar", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@IdServicio", IdServicio);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oServicios.IdServicio = Convert.ToInt32(dr["IdServicio"]);
                                oServicios.Descripcion = dr["Descripcion"].ToString();
                                oServicios.TipoServicio = dr["TipoServicio"].ToString();
                                oServicios.Precio = Convert.ToDouble(dr["Precio"]);
                                oServicios.Estado = dr["Estado"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return oServicios;
        }


        // Metodo que elimina datos
        public bool MtdEliminarServicios(int IdServicio)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_servicios_eliminar", sqlConnection); 
                    cmd.Parameters.AddWithValue("@IdServicio", IdServicio);
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

    }
}
