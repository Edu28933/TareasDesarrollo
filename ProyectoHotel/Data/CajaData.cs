using ProyectoHotel.Models;
using Microsoft.Data.SqlClient;
using System.Data;



namespace ProyectoHotel.Data
{
    public class CajaData
    {
        public List<CajaModel> MtdConsultarCaja()
        {
            var oListaCaja = new List<CajaModel>();
            var conn = new Conexion();

            using (var CadenaConexion = new SqlConnection(conn.GetConnectionString()))
            {
                try
                {
                    CadenaConexion.Open();
                    SqlCommand cmd = new SqlCommand("usp_Caja_Mostrar", CadenaConexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaCaja.Add(new CajaModel
                            {
                                IdCaja = Convert.ToInt32(dr["IdCaja"]),
                                IdPagoPlanilla = Convert.ToInt32(dr["IdPagoPlanilla"]),
                                IdPago = Convert.ToInt32(dr["IdPago"]),
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]),
                                FechaSalida = Convert.ToDateTime(dr["FechaSalida"]),
                                TotalPagoPlanilla = Convert.ToDouble(dr["TotalPagoPlanilla"]),
                                TotalPagos = Convert.ToDouble(dr["TotalPagos"]),
                                TotalCompras = Convert.ToDouble(dr["TotalCompras"]),
                                GananciaTotal = Convert.ToDouble(dr["GananciaTotal"]),
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
            return oListaCaja;
        }


        public bool MtdAgregarCaja(CajaModel oCaja)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_Caja_Agregar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdPagoPlanilla", oCaja.IdPagoPlanilla);
                    cmd.Parameters.AddWithValue("@IdPago", oCaja.IdPago);
                    cmd.Parameters.AddWithValue("@IdCompra", oCaja.IdCompra);
                    cmd.Parameters.AddWithValue("@Descripcion", oCaja.Descripcion);
                    cmd.Parameters.AddWithValue("@FechaIngreso", oCaja.FechaIngreso);
                    cmd.Parameters.AddWithValue("@FechaSalida", oCaja.FechaSalida);
                    cmd.Parameters.AddWithValue("@TotalPagoPlanilla", oCaja.TotalPagoPlanilla);
                    cmd.Parameters.AddWithValue("@TotalPagos", oCaja.TotalPagos);
                    cmd.Parameters.AddWithValue("@TotalCompras", oCaja.TotalCompras);
                    cmd.Parameters.AddWithValue("@GananciaTotal", oCaja.GananciaTotal);
                    cmd.Parameters.AddWithValue("@Estado", oCaja.Estado);
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



        public CajaModel MtdBuscarCaja(int IdCaja)
        {
            var oCaja = new CajaModel();

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    using (var cmd = new SqlCommand("ssp_Caja_Buscar", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@IdCaja", IdCaja);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oCaja.IdCaja = Convert.ToInt32(dr["IdCaja"]);
                                oCaja.IdPagoPlanilla = Convert.ToInt32(dr["IdPagoPlanilla"]);
                                oCaja.IdPago = Convert.ToInt32(dr["IdPago"]);
                                oCaja.IdCompra = Convert.ToInt32(dr["IdCompra"]);
                                oCaja.Descripcion = dr["Descripcion"].ToString();
                                oCaja.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                                oCaja.FechaSalida = Convert.ToDateTime(dr["FechaSalida"]);
                                oCaja.TotalPagoPlanilla = Convert.ToDouble(dr["TotalPagoPlanilla"]);
                                oCaja.TotalPagos = Convert.ToDouble(dr["TotalPagos"]);
                                oCaja.TotalCompras = Convert.ToDouble(dr["TotalCompras"]);
                                oCaja.GananciaTotal = Convert.ToDouble(dr["GananciaTotal"]);
                                oCaja.Estado = dr["Estado"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return oCaja;
        }



        public bool MtdEditarCaja(CajaModel oCaja)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("ssp_Caja_Editar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdCaja", oCaja.IdCaja);
                    cmd.Parameters.AddWithValue("@IdPagoPlanilla", oCaja.IdPagoPlanilla);
                    cmd.Parameters.AddWithValue("@IdPago", oCaja.IdPago);
                    cmd.Parameters.AddWithValue("@IdCompra", oCaja.IdCompra);
                    cmd.Parameters.AddWithValue("@Descripcion", oCaja.Descripcion);
                    cmd.Parameters.AddWithValue("@FechaIngreso", oCaja.FechaIngreso);
                    cmd.Parameters.AddWithValue("@FechaSalida", oCaja.FechaSalida);
                    cmd.Parameters.AddWithValue("@TotalPagoPlanilla", oCaja.TotalPagoPlanilla);
                    cmd.Parameters.AddWithValue("@TotalPagos", oCaja.TotalPagos);
                    cmd.Parameters.AddWithValue("@TotalCompras", oCaja.TotalCompras);
                    cmd.Parameters.AddWithValue("@GananciaTotal", oCaja.GananciaTotal);
                    cmd.Parameters.AddWithValue("@Estado", oCaja.Estado);
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

        public bool MtdEliminarCaja(int IdCaja)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_Caja_Eliminar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdCaja", IdCaja);
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
