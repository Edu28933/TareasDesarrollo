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
                                Salario = Convert.ToDouble(dr["Salario"]),
                                Cui = Convert.ToInt32(dr["Cui"]),
                                Nacionalidad = dr["Nacionalidad"].ToString(),
                                FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]),
                                FechaSalida = Convert.ToDateTime(dr["FechaSalida"]),
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
            return oListaEmpleados;
        }

        public bool MtdAgregarEmpleados(EmpleadosModel oEmpleados)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();
                ;
                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_Empleados_Agregar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdSucursal", oEmpleados.IdSucursal);
                    cmd.Parameters.AddWithValue("@Nombres", oEmpleados.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", oEmpleados.Apellidos);
                    cmd.Parameters.AddWithValue("@Telefono", oEmpleados.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", oEmpleados.Direccion);
                    cmd.Parameters.AddWithValue("@TipoEmpleado", oEmpleados.TipoEmpleado);
                    cmd.Parameters.AddWithValue("@Puesto", oEmpleados.Puesto);
                    cmd.Parameters.AddWithValue("@Salario", oEmpleados.Salario);
                    cmd.Parameters.AddWithValue("@Cui", oEmpleados.Cui);
                    cmd.Parameters.AddWithValue("@Nacionalidad", oEmpleados.Nacionalidad);
                    cmd.Parameters.AddWithValue("@FechaIngreso", oEmpleados.FechaIngreso);
                    cmd.Parameters.AddWithValue("@FechaSalida", oEmpleados.FechaSalida);
                    cmd.Parameters.AddWithValue("@Estado", oEmpleados.Estado);
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


        public bool MtdEditarEmpleados(EmpleadosModel oEmpleados)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_Empleados_Modificar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdEmpleado", oEmpleados.IdEmpleado);
                    cmd.Parameters.AddWithValue("@IdSucursal", oEmpleados.IdSucursal);
                    cmd.Parameters.AddWithValue("@Nombres", oEmpleados.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", oEmpleados.Apellidos);
                    cmd.Parameters.AddWithValue("@Telefono", oEmpleados.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", oEmpleados.Direccion);
                    cmd.Parameters.AddWithValue("@TipoEmpleado", oEmpleados.TipoEmpleado);
                    cmd.Parameters.AddWithValue("@Puesto", oEmpleados.Puesto);
                    cmd.Parameters.AddWithValue("@Salario", oEmpleados.Salario);
                    cmd.Parameters.AddWithValue("@Cui", oEmpleados.Cui);
                    cmd.Parameters.AddWithValue("@Nacionalidad", oEmpleados.Nacionalidad);
                    cmd.Parameters.AddWithValue("@FechaIngreso", oEmpleados.FechaIngreso);
                    cmd.Parameters.AddWithValue("@FechaSalida", oEmpleados.FechaSalida);
                    cmd.Parameters.AddWithValue("@Estado", oEmpleados.Estado);
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


        public bool MtdEliminarEmpleados(int IdEmpleado)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_Empleados_Eliminar", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
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



        

        public EmpleadosModel MtdBuscarEmpleados(int IdEmpleado)
        {
            var oEmpleado = new EmpleadosModel();

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    using (var cmd = new SqlCommand("usp_Empleados_Buscar", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oEmpleado.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]);
                                oEmpleado.IdSucursal = Convert.ToInt32(dr["IdSucursal"]);
                                oEmpleado.Nombres = dr["Nombres"].ToString();
                                oEmpleado.Apellidos = dr["Apellidos"].ToString();
                                oEmpleado.Telefono = Convert.ToInt32(dr["Telefono"]);
                                oEmpleado.Direccion = dr["Direccion"].ToString();
                                oEmpleado.TipoEmpleado = dr["TipoEmpleado"].ToString();
                                oEmpleado.Puesto = dr["Puesto"].ToString();
                                oEmpleado.Salario = Convert.ToDouble(dr["Salario"]);
                                oEmpleado.Cui = Convert.ToInt32(dr["Cui"]);
                                oEmpleado.Nacionalidad = dr["Nacionalidad"].ToString();
                                oEmpleado.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                                oEmpleado.FechaSalida = Convert.ToDateTime(dr["FechaSalida"]);
                                oEmpleado.Estado = dr["Estado"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return oEmpleado;
        }

    }
}