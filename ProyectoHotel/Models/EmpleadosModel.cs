namespace ProyectoHotel.Models
{
    public class EmpleadosModel
    {
        public int IdEmpleado { get; set; }
        public int IdSucursal { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? TipoEmpleado { get; set; }
        public string? Puesto { get; set; }
        public double Salario { get; set; }
        public int Cui { get; set; }
        public string? Nacionalidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string? Estado { get; set; }

    }
}
