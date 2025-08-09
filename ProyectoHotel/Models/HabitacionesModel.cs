namespace ProyectoHotel.Models
{
    public class HabitacionesModel
    {
        public int IdHabitacion { get; set; } 

        public int  Capacidad {  get; set; } 

        public string? TipoHabitacion { get; set; } 

        public string? Disponibilidad { get; set; } 

        public string? Descripcion { get; set; }

        public string? Ubicacion { get; set; } 

        public double PrecioHabitacion { get; set; } 
    }
}
