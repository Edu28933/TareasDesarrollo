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
                    SqlCommand cmd = new SqlCommand("usp_Horarios_Mostrar", CadenaConexion) //Cambiar nombre usp 
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
                    SqlCommand cmd = new SqlCommand("usp_Horarios_Crear", sqlConnection);
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


        // Metodo que actualiza datos
        public bool MtdEditarHorarios(HorariosModel oHorarios)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_Horarios_Editar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdHorario", oHorarios.IdHorario);
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

        // Método que busca un dato por su código
        public HorariosModel MtdBuscarHorarios(int IdHorario)
        {
            var oHorarios = new HorariosModel();

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    using (var cmd = new SqlCommand("usp_Horarios_Buscar", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@IdHorario", IdHorario);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oHorarios.IdHorario = Convert.ToInt32(dr["IdHorario"]);
                                oHorarios.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]);
                                oHorarios.Jornada = dr["Jornada"].ToString();
                                oHorarios.Turno = dr["Turno"].ToString();
                                oHorarios.HoraInicio = TimeSpan.TryParse(dr["HoraInicio"]?.ToString(), out var tsInicio) ? tsInicio : TimeSpan.Zero;
                                oHorarios.HoraFin = TimeSpan.TryParse(dr["HoraFin"]?.ToString(), out var tsFin) ? tsFin : TimeSpan.Zero;
                                oHorarios.Estado = dr["Estado"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return oHorarios;
        }


        public bool MtdEliminarHorarios(int IdHorario)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_Horario_Eliminar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdHorario", IdHorario);
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
