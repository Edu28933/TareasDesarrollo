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

        // Muestra el formulario llamador Modificar
        public IActionResult Modificar(int IdCliente)
        {
            var oCliente = _ClientesData.MtdBuscarClientes(IdCliente);
            return View(oCliente);

        }

        // Almacena los datos del formulario Modificar
        [HttpPost]
        public IActionResult Modificar(ClientesModel oCliente) //Cambiar
        {
            var respuesta = _ClientesData.MtdEditarClientes(oCliente); //Cambiar

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
        public IActionResult Eliminar(int IdCliente)
        {
            var oClientes = _ClientesData.MtdBuscarClientes(IdCliente);
            return View(oClientes);
        }

        // Envia los datos del formulario Eliminar
        [HttpPost]
        public IActionResult Eliminar(ClientesModel oCliente)
        {
            var respuesta = _ClientesData.MtdEliminarClientes(oCliente.IdCliente);

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
