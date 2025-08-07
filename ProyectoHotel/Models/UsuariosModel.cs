namespace ProyectoHotel.Models
{
    public class UsuariosModel
    {
        public int IdUsuario { get; set; }
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Clave { get; set; }
        public string? Estado { get; set; }
        public string? Rol { get; set; }
    }
}
