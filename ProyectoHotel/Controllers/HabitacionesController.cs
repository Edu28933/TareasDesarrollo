
using Microsoft.AspNetCore.Mvc;
using ProyectoHotel.Data;
using ProyectoHotel.Models;


namespace ProyectoHotel.Controllers
{
    public class HabitacionesController : Controller
    {
        HabitacionesData _HabitacionesData = new HabitacionesData();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listar()
        {
            var oListaHabitaciones = _HabitacionesData.MtdConsultarHabitaciones();
            return View(oListaHabitaciones);
        }


        // Muestra el formulario llamador Guardar
        public IActionResult Guardar()
        {
            return View();
        }

        // Almacena los datos del formulario Guardar
        [HttpPost]
        public IActionResult Guardar(HabitacionesModel oHabitaciones)
        {
            var respuesta = _HabitacionesData.MtdAgregarHabitaciones(oHabitaciones);

            if (respuesta == true)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
