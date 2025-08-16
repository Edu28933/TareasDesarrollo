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

        // Muestra el formulario Guardar
        public IActionResult Guardar()
        {
            return View();
        }

        // Almacena los datos del formulario Guardar
        [HttpPost]
        public IActionResult Guardar(HabitacionesModel oHabitacion)
        {
            var respuesta = _HabitacionesData.MtdAgregarHabitaciones(oHabitacion);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(oHabitacion);
            }
        }

        // Muestra el formulario Modificar
        public IActionResult Modificar(int IdHabitacion)
        {
            var oHabitacion = _HabitacionesData.MtdBuscarHabitaciones(IdHabitacion);
            return View(oHabitacion);
        }

        // Almacena los datos del formulario Modificar
        [HttpPost]
        public IActionResult Modificar(HabitacionesModel oHabitacion)
        {
            var respuesta = _HabitacionesData.MtdEditarHabitaciones(oHabitacion);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(oHabitacion);
            }
        }

        // Muestra el formulario Eliminar
        public IActionResult Eliminar(int IdHabitacion)
        {
            var oHabitacion = _HabitacionesData.MtdBuscarHabitaciones(IdHabitacion);

            if (oHabitacion == null || oHabitacion.IdHabitacion == 0)
            {
                return RedirectToAction("Listar"); // Evita error si no existe
            }

            return View(oHabitacion);
        }

        // POST para eliminar
        [HttpPost]
        public IActionResult Eliminar(HabitacionesModel oHabitacion)
        {
            if (oHabitacion == null || oHabitacion.IdHabitacion == 0)
            {
                return RedirectToAction("Listar");
            }

            var respuesta = _HabitacionesData.MtdEliminarHabitaciones(oHabitacion.IdHabitacion);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                // En caso de fallo, se puede mostrar mensaje o recargar vista
                return View(oHabitacion);
            }
        }
    }

    }
    

