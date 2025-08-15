using Microsoft.AspNetCore.Mvc;
using ProyectoHotel.Data;
using ProyectoHotel.Models;



    namespace ProyectoHotel.Controllers
{
    public class ReservacionesController : Controller
    {

        ReservacionesData _ReservacionesData = new ReservacionesData();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listar()
        {
            var oListaReservaciones = _ReservacionesData.MtdConsultarReservaciones();
            return View(oListaReservaciones);
        }

        // Muestra el formulario llamador Guardar
        public IActionResult Guardar()
        {
            return View();
        }

        // Almacena los datos del formulario Guardar
        [HttpPost]
        public IActionResult Guardar(ReservacionesModel oReservaciones)
        {
            var respuesta = _ReservacionesData.MtdAgregarReservaciones(oReservaciones);

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
