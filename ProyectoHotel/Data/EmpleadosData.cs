using ProyectoHotel.Models;
using Microsoft.Data.SqlClient;
using System.Data;



namespace ProyectoHotel.Data
{
    public class EmpleadosData
    {


        public List<EmpleadosModel> MtdConsultarEmpleados()
        {
            var oListaEmpleados = new List<EmpleadosModel>();
            var conn = new Conexion();

            using (var CadenaConexion = new SqlConnection(conn.GetConnectionString()))
            {
                try
                {
                    CadenaConexion.Open();
                    SqlCommand cmd = new SqlCommand("usp_Empleados_Mostrar", CadenaConexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaEmpleados.Add(new EmpleadosModel
                            {
                                IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                                IdSucursal = Convert.ToInt32(dr["IdSucursal"]),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                Telefono = Convert.ToInt32(dr["Telefono"]),
                                Direccion = dr["Direccion"].ToString(),
                                TipoEmpleado = dr["TipoEmpleado"].ToString(),
                                Puesto = dr["Puesto"].ToString(),
                                Salario = Convert.ToDouble(dr["IdSucursal"]),
                                Cui = Convert.ToInt32(dr["Cui"]),
                                Nacionalidad = dr["Nacionalidad"].ToString(),
                                FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]),
                                FechaSalida = Convert.ToDateTime(dr["FechaSalida"]),
                                Estado= dr["Estado"].ToString(),
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return oListaEmpleados;
        }


    }
}
