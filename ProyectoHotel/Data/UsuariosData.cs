using ProyectoHotel.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ProyectoHotel.Data
{
    public class UsuariosData
    {


        public List<UsuariosModel> MtdConsultarUsuarios()
        {
            var oListaUsuarios = new List<UsuariosModel>();
            var conn = new Conexion();

            using (var CadenaConexion = new SqlConnection(conn.GetConnectionString()))
            {
                try
                {
                    CadenaConexion.Open();
                    SqlCommand cmd = new SqlCommand("usp_Usuarios_Mostrar", CadenaConexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaUsuarios.Add(new UsuariosModel
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                                Nombre = dr["Nombre"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                Rol = dr["Rol"].ToString(),
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return oListaUsuarios;
        } 



    }
}
