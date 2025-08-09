namespace ProyectoHotel.Models
{
    public class ClientesModel
    {
        public int IdCliente { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Direccion { get; set; }
        public string? Cui { get; set; }
        public int Telefono { get; set; }
        public string? Estado { get; set; }
    }
}
