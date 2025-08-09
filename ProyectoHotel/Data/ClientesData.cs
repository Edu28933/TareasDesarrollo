using Microsoft.Data.SqlClient;
using ProyectoHotel.Models;
using System.Data;

namespace ProyectoHotel.Data
{
    public class ClientesData
    {
        // Metodo que consulta datos
        public List<ClientesModel> MtdConsultarClientes() //1. CambiarelNombre
        {
            var oListaClientes = new List<ClientesModel>(); //2. CambiarNombre
            var conn = new Conexion();

            using (var CadenaConexion = new SqlConnection(conn.GetConnectionString()))
            {
                try
                {
                    CadenaConexion.Open();
                    SqlCommand cmd = new SqlCommand("usp_clientes_mostrar", CadenaConexion) //Cambiar nombre usp 
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaClientes.Add(new ClientesModel //3
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Cui = dr["Cui"].ToString(),
                                Telefono = Convert.ToInt32(dr["Telefono"]),
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
            return oListaClientes;
        }


        // Metodo que agrega datos
        public bool MtdAgregarClientes(ClientesModel oClientes)
        {
            bool respuesta = false;

            try
            {
                var conn = new Conexion();

                using (var sqlConnection = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_clientes_crear", sqlConnection);
                    cmd.Parameters.AddWithValue("@Nombres", oClientes.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", oClientes.Apellidos);
                    cmd.Parameters.AddWithValue("@Direccion", oClientes.Direccion);
                    cmd.Parameters.AddWithValue("@Cui", oClientes.Cui);
                    cmd.Parameters.AddWithValue("@Telefono", oClientes.Telefono);
                    cmd.Parameters.AddWithValue("@Estado", oClientes.Estado);
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
