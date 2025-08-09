using Microsoft.Data.SqlClient;
using ProyectoHotel.Models;
using System.Data;

namespace ProyectoHotel.Data
{
    public class HorariosData
    {
        // Metodo que consulta datos
        public List<HorariosModel> MtdConsultarHorarios() //1. CambiarelNombre
        {
            var oListaHorarios = new List<HorariosModel>(); //2. CambiarNombre
            var conn = new Conexion();

            using (var CadenaConexion = new SqlConnection(conn.GetConnectionString()))
            {
                try
                {
                    CadenaConexion.Open();
                    SqlCommand cmd = new SqlCommand("usp_horarios_mostrar", CadenaConexion) //Cambiar nombre usp 
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaHorarios.Add(new HorariosModel //3
                            {
                                IdHorario = Convert.ToInt32(dr["IdHorario"]),
                                IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                                Jornada = dr["Jornada"].ToString(),
                                Turno = dr["Turno"].ToString(),
                                HoraInicio = TimeSpan.TryParse(dr["HoraInicio"]?.ToString(), out var tsInicio) ? tsInicio : TimeSpan.Zero,
                                HoraFin = TimeSpan.TryParse(dr["HoraFin"]?.ToString(), out var tsFin) ? tsFin : TimeSpan.Zero,
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
            return oListaHorarios;
        }

        // Metodo que agrega datos
        public bool MtdAgregarHorarios(HorariosModel oHorarios)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_horarios_crear", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdEmpleado", oHorarios.IdEmpleado);
                    cmd.Parameters.AddWithValue("@Jornada", oHorarios.Jornada);
                    cmd.Parameters.AddWithValue("@Turno", oHorarios.Turno);
                    cmd.Parameters.AddWithValue("@HoraInicio", oHorarios.HoraInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", oHorarios.HoraFin);
                    cmd.Parameters.AddWithValue("@Estado", oHorarios.Estado);
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
