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

    }
}
