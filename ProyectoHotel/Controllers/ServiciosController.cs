using Microsoft.AspNetCore.Mvc;
using ProyectoHotel.Models;
using ProyectoHotel.Data;


namespace ProyectoHotel.Controllers
{
    public class ServiciosController : Controller
    {

        // Instancia de la clase con la conexion y stored procedures
        ServiciosData _ServiciosData = new ServiciosData(); //CambiarNombre de la carpeta de Data

        // Muestra el formulario princal con la lista de datos
        public IActionResult Listar()
        {
            var oListaServicios = _ServiciosData.MtdConsultarServicios(); //Cambiar
            return View(oListaServicios);
        }


        // Muestra el formulario llamador Guardar
        public IActionResult Guardar()
        {
            return View();
        }

        // Almacena los datos del formulario Guardar
        [HttpPost]
        public IActionResult Guardar(ServiciosModel oServicio) //Cambiar
        {
            var respuesta = _ServiciosData.MtdAgregarServicios(oServicio); //Cambiar

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
