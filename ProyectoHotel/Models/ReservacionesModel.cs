namespace ProyectoHotel.Models
{
    public class ReservacionesModel
    {
        public int IdReservacion { get; set; }

        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }

        public string? TipoReservacion { get; set; }

        public string? Descripcion { get; set; }

        public DateTime FechaIngreso {  get; set; } 

        public DateTime FechaSalida { get; set; }

        public TimeSpan HoraIngreso { get; set; }
        public TimeSpan HoraSalida { get; set; } 

        public string? Estado {  get; set; } 


    }
}
