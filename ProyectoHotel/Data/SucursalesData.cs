using Microsoft.Data.SqlClient;
using ProyectoHotel.Data;
using ProyectoHotel.Models;
using System.Data;


    public class SucursalesData
    {
    public List<SucursalesModel> MtdConsultarSucursales()
    {
        var oListaSucursales  = new List<SucursalesModel>();
        var conn = new Conexion();

        using (var CadenaConexion = new SqlConnection(conn.GetConnectionString()))
        {
            try
            {
                CadenaConexion.Open();
                SqlCommand cmd = new SqlCommand("usp_Sucursales_Mostrar", CadenaConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListaSucursales.Add(new SucursalesModel
                        {
                            IdSucursal = Convert.ToInt32(dr["IdSucursal"]),
                            Nombre = dr["Nombre"].ToString(),
                            Departamento = dr["Departamento"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            Capacidad = Convert.ToInt32(dr["Capacidad"]),
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
        return oListaSucursales;  
    }


    // Metodo que agrega datos
    public bool MtdAgregarSucursales(SucursalesModel oSucursales)
    {
        bool respuesta = false;

        try
        {
            var conn = new Conexion();

            using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("usp_Sucursales_Crear", sqlConnection);
                cmd.Parameters.AddWithValue("@Nombre", oSucursales.Nombre);
                cmd.Parameters.AddWithValue("@Departamento", oSucursales.Departamento);
                cmd.Parameters.AddWithValue("@Ubicacion", oSucursales.Ubicacion);
                cmd.Parameters.AddWithValue("@Capacidad", oSucursales.Capacidad);
                cmd.Parameters.AddWithValue("@Estado", oSucursales.Estado);
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
