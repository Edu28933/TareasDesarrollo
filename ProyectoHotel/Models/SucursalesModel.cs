namespace ProyectoHotel.Models
{
    public class SucursalesModel
    {
        public int IdSucursal { get; set; } 
        public string? Nombre { get; set; }  

        public string? Departamento { get; set; }   

        public string? Ubicacion {  get; set; }  

        public int Capacidad { get; set; }   

        public string? Estado { get; set; } 
    }
}
