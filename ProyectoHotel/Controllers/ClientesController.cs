using Microsoft.AspNetCore.Mvc;
using ProyectoHotel.Data;
using ProyectoHotel.Models;

namespace ProyectoHotel.Controllers
{
    public class ClientesController : Controller
    {

        // Instancia de la clase con la conexion y stored procedures
        ClientesData _ClientesData = new ClientesData(); //CambiarNombre de la carpeta de Data

        // Muestra el formulario princal con la lista de datos
        public IActionResult Listar()
        {
            var oListaClientes = _ClientesData.MtdConsultarClientes(); //Cambiar
            return View(oListaClientes);
        }

        // Muestra el formulario llamador Guardar
        public IActionResult Guardar()
        {
            return View();
        }

        // Almacena los datos del formulario Guardar
        [HttpPost]
        public IActionResult Guardar(ClientesModel oCliente) //Cambiar
        {
            var respuesta = _ClientesData.MtdAgregarClientes(oCliente); //Cambiar

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
