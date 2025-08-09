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
    }
}
