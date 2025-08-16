using Microsoft.Data.SqlClient;
using ProyectoHotel.Models;
using System.Data;

namespace ProyectoHotel.Data
{
    public class HabitacionesData
    {
        public List<HabitacionesModel> MtdConsultarHabitaciones()
        {
            var oListaHabitaciones = new List<HabitacionesModel>();
            var conn = new Conexion();

            using (var CadenaConexion = new SqlConnection(conn.GetConnectionString()))
            {
                try
                {
                    CadenaConexion.Open();
                    SqlCommand cmd = new SqlCommand("usp_habitaciones_mostrar", CadenaConexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaHabitaciones.Add(new HabitacionesModel
                            {
                                IdHabitacion = Convert.ToInt32(dr["IdHabitacion"]),
                                Capacidad = Convert.ToInt32(dr["Capacidad"]),
                                TipoHabitacion = dr["TipoHabitacion"].ToString(),
                                Disponibilidad = dr["Disponibilidad"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                PrecioHabitacion = Convert.ToDouble(dr["PrecioHabitacion"]),

                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return oListaHabitaciones;
        }


        // Metodo que agrega datos
        public bool MtdAgregarHabitaciones(HabitacionesModel oHabitaciones)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_habitaciones_crear", sqlConnection);
                    cmd.Parameters.AddWithValue("@Capacidad", oHabitaciones.Capacidad);
                    cmd.Parameters.AddWithValue("@TipoHabitacion", oHabitaciones.TipoHabitacion);
                    cmd.Parameters.AddWithValue("@Disponibilidad", oHabitaciones.Disponibilidad);
                    cmd.Parameters.AddWithValue("@Descripcion", oHabitaciones.Descripcion);
                    cmd.Parameters.AddWithValue("@Ubicacion", oHabitaciones.Ubicacion);
                    cmd.Parameters.AddWithValue("@PrecioHabitacion", oHabitaciones.PrecioHabitacion);
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
        public bool MtdEditarHabitaciones(HabitacionesModel oHabitaciones)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_habitaciones_actualizar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdHabitacion", oHabitaciones.IdHabitacion); // ✅ Corregido aquí
                    cmd.Parameters.AddWithValue("@Capacidad", oHabitaciones.Capacidad);
                    cmd.Parameters.AddWithValue("@TipoHabitacion", oHabitaciones.TipoHabitacion);
                    cmd.Parameters.AddWithValue("@Disponibilidad", oHabitaciones.Disponibilidad);
                    cmd.Parameters.AddWithValue("@Descripcion", oHabitaciones.Descripcion);
                    cmd.Parameters.AddWithValue("@Ubicacion", oHabitaciones.Ubicacion);
                    cmd.Parameters.AddWithValue("@PrecioHabitacion", oHabitaciones.PrecioHabitacion);
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
        public HabitacionesModel MtdBuscarHabitaciones(int IdHabitacion)
        {
            var oHabitaciones = new HabitacionesModel();

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    using (var cmd = new SqlCommand("usp_habitaciones_buscar", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@IdHabitacion", IdHabitacion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oHabitaciones.IdHabitacion = Convert.ToInt32(dr["IdHabitacion"]);
                                oHabitaciones.Capacidad = Convert.ToInt32(dr["Capacidad"]);
                                oHabitaciones.TipoHabitacion = dr["TipoHabitacion"].ToString();
                                oHabitaciones.Disponibilidad = dr["Disponibilidad"].ToString();
                                oHabitaciones.Descripcion = dr["Descripcion"].ToString();
                                oHabitaciones.Ubicacion = dr["Ubicacion"].ToString();
                                oHabitaciones.PrecioHabitacion = Convert.ToDouble(dr["PrecioHabitacion"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return oHabitaciones;
        }



        // Metodo que elimina datos
        public bool MtdEliminarHabitaciones(int IdHabitacion)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_habitaciones_eliminar", sqlConnection); // ✅ Cambiado
                    cmd.Parameters.AddWithValue("@IdHabitacion", IdHabitacion); // ✅ Nombre coherente
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
