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

        // Muestra el formulario para modificar una reservación
        public IActionResult Modificar(int IdReservacion)
        {
            var oReservaciones = _ReservacionesData.MtdBuscarReservaciones(IdReservacion);
            return View(oReservaciones);
        }

        // Almacena los datos del formulario Modificar
        [HttpPost]
        public IActionResult Modificar(ReservacionesModel oReservaciones)
        {
            var respuesta = _ReservacionesData.MtdEditarReservaciones(oReservaciones);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(oReservaciones);
            }
        }

        // Muestra el formulario para eliminar una reservación
        public IActionResult Eliminar(int IdReservacion)
        {
            var oReservaciones = _ReservacionesData.MtdBuscarReservaciones(IdReservacion);
            return View(oReservaciones);
        }

        // Envía los datos del formulario Eliminar
        [HttpPost]
        public IActionResult Eliminar(ReservacionesModel oReservaciones)
        {
            var respuesta = _ReservacionesData.MtdEliminarReservaciones(oReservaciones.IdReservacion);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(oReservaciones);
            }
        }
    }
}

    