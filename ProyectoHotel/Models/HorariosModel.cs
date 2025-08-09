namespace ProyectoHotel.Models
{
    public class HorariosModel
    {
        public int IdHorario { get; set; }
        public int IdEmpleado { get; set; }
        public string? Jornada { get; set; }
        public string? Turno { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string? Estado { get; set; }
    }
}
