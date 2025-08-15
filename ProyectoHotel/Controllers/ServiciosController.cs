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

        // Muestra el formulario llamador Modificar
        public IActionResult Modificar(int IdServicio)
        {
            var oServicio = _ServiciosData.MtdBuscarServicios(IdServicio);
            return View(oServicio);

        }

        // Almacena los datos del formulario Modificar
        [HttpPost]
        public IActionResult Modificar(ServiciosModel oServicio) //Cambiar
        {
            var respuesta = _ServiciosData.MtdEditarServicios(oServicio); //Cambiar

            if (respuesta == true)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }


        // Muestra el formulario llamador Eliminar
        public IActionResult Eliminar(int IdServicio)
        {
            var oServicios = _ServiciosData.MtdBuscarServicios(IdServicio);
            return View(oServicios);
        }

        // Envia los datos del formulario Eliminar
        [HttpPost]
        public IActionResult Eliminar(ServiciosModel oServicio)
        {
            var respuesta = _ServiciosData.MtdEliminarServicios(oServicio.IdServicio);

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
