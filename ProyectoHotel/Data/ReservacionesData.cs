using Microsoft.Data.SqlClient;
namespace ProyectoHotel.Data; 
using ProyectoHotel.Models;
using System.Data;



    public class ReservacionesData
    {
    public List<ReservacionesModel> MtdConsultarReservaciones()
    {
        var oListaReservaciones = new List<ReservacionesModel>();
        var conn = new Conexion();

        using (var CadenaConexion = new SqlConnection(conn.GetConnectionString()))
        {
            try
            {
                CadenaConexion.Open();
                SqlCommand cmd = new SqlCommand("usp_reservaciones_mostrar", CadenaConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListaReservaciones.Add(new ReservacionesModel
                        {
                            IdReservacion = Convert.ToInt32(dr["IdReservacion"]),
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            IdHabitacion = Convert.ToInt32(dr["IdHabitacion"]),
                            TipoReservacion = dr["TipoReservacion"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]),
                            FechaSalida = Convert.ToDateTime(dr["FechaSalida"]),
                            HoraIngreso = dr["HoraIngreso"] != DBNull.Value ? (TimeSpan)dr["HoraIngreso"] : TimeSpan.Zero,
                            HoraSalida = dr["HoraSalida"] != DBNull.Value ? (TimeSpan)dr["HoraSalida"] : TimeSpan.Zero


                        });
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        return oListaReservaciones;
    }


    // Metodo que agrega datos
    public bool MtdAgregarReservaciones(ReservacionesModel oReservaciones)
    {
        bool respuesta = false;

        try
        {
            var conn = new Conexion();

            using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("usp_reservaciones_crear", sqlConnection);
                cmd.Parameters.AddWithValue("@IdCliente", oReservaciones.IdCliente);
                cmd.Parameters.AddWithValue("@IdHabitacion", oReservaciones.IdHabitacion);
                cmd.Parameters.AddWithValue("@TipoReservacion", oReservaciones.TipoReservacion);
                cmd.Parameters.AddWithValue("@Descripcion", oReservaciones.Descripcion);
                cmd.Parameters.AddWithValue("@FechaIngreso", oReservaciones.FechaIngreso);
                cmd.Parameters.AddWithValue("@FechaSalida", oReservaciones.FechaSalida);
                cmd.Parameters.AddWithValue("@HoraIngreso", oReservaciones.HoraIngreso);
                cmd.Parameters.AddWithValue("@HoraSalida", oReservaciones.HoraSalida);
                cmd.Parameters.AddWithValue("@Estado", oReservaciones.Estado);
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


    // Método que edita una reservación
    public bool MtdEditarReservaciones(ReservacionesModel oReservaciones)
    {
        bool respuesta = false;
        try
        {
            var conn = new Conexion();
            using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("usp_reservaciones_actualizar", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdReservacion", oReservaciones.IdReservacion);
                cmd.Parameters.AddWithValue("@IdCliente", oReservaciones.IdCliente);
                cmd.Parameters.AddWithValue("@IdHabitacion", oReservaciones.IdHabitacion);
                cmd.Parameters.AddWithValue("@TipoReservacion", oReservaciones.TipoReservacion);
                cmd.Parameters.AddWithValue("@Descripcion", oReservaciones.Descripcion);
                cmd.Parameters.AddWithValue("@FechaIngreso", oReservaciones.FechaIngreso);
                cmd.Parameters.AddWithValue("@FechaSalida", oReservaciones.FechaSalida);
                cmd.Parameters.AddWithValue("@HoraIngreso", oReservaciones.HoraIngreso);
                cmd.Parameters.AddWithValue("@HoraSalida", oReservaciones.HoraSalida);
                cmd.Parameters.AddWithValue("@Estado", oReservaciones.Estado);
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

    // Método que busca una reservación por su Id
    public ReservacionesModel MtdBuscarReservaciones(int IdReservacion)
    {
        var oReservaciones = new ReservacionesModel();
        try
        {
            var conn = new Conexion();
            using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
            {
                sqlConnection.Open();
                using (var cmd = new SqlCommand("usp_reservaciones_buscar", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdReservacion", IdReservacion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oReservaciones.IdReservacion = Convert.ToInt32(dr["IdReservacion"]);
                            oReservaciones.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                            oReservaciones.IdHabitacion = Convert.ToInt32(dr["IdHabitacion"]);
                            oReservaciones.TipoReservacion = dr["TipoReservacion"].ToString();
                            oReservaciones.Descripcion = dr["Descripcion"].ToString();
                            oReservaciones.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                            oReservaciones.FechaSalida = Convert.ToDateTime(dr["FechaSalida"]);
                            oReservaciones.HoraIngreso = dr["HoraIngreso"] != DBNull.Value ? (TimeSpan)dr["HoraIngreso"] : TimeSpan.Zero;
                            oReservaciones.HoraSalida = dr["HoraSalida"] != DBNull.Value ? (TimeSpan)dr["HoraSalida"] : TimeSpan.Zero;
                            oReservaciones.Estado = dr["Estado"].ToString();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }
        return oReservaciones;
    }

    // Método que elimina una reservación
    public bool MtdEliminarReservaciones(int IdReservacion)
    {
        bool respuesta = false;
        try
        {
            var conn = new Conexion();
            using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("usp_reservaciones_eliminar", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdReservacion", IdReservacion);
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


