using Microsoft.AspNetCore.Mvc;
using ProyectoHotel.Data;
using ProyectoHotel.Models;

namespace ProyectoHotel.Controllers
{
    public class HorariosController : Controller
    {
        // Instancia de la clase con la conexion y stored procedures
        HorariosData _HorariosData = new HorariosData(); //CambiarNombre de la carpeta de Data

        // Muestra el formulario princal con la lista de datos
        public IActionResult Listar()
        {
            var oListaHorarios = _HorariosData.MtdConsultarHorarios(); //Cambiar
            return View(oListaHorarios);
        }

        // Muestra el formulario llamador Guardar
        public IActionResult Guardar()
        {
            return View();
        }

        // Almacena los datos del formulario Guardar
        [HttpPost]
        public IActionResult Guardar(HorariosModel oHorario) //Cambiar
        {
            var respuesta = _HorariosData.MtdAgregarHorarios(oHorario); //Cambiar

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
