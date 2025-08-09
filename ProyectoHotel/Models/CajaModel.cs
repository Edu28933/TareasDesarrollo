namespace ProyectoHotel.Models
{
    public class CajaModel
    {
        public int IdCaja { get; set; }
        public int IdPagoPlanilla { get; set; }
        public int IdPago { get; set; }
        public int IdCompra { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public double TotalPagoPlanilla { get; set; }
        public double TotalPagos { get; set; }
        public double TotalCompras { get; set; }
        public double GananciaTotal { get; set; }
        public string? Estado { get; set; }

    }
}
