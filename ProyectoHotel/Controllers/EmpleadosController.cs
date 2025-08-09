using Microsoft.AspNetCore.Mvc;
using ProyectoHotel.Models;
using ProyectoHotel.Data;


namespace ProyectoHotel.Controllers
{

    public class EmpleadosController : Controller
    {
        EmpleadosData _EmpleadosData = new EmpleadosData();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listar()
        {
            var oListaEmpleados = _EmpleadosData.MtdConsultarEmpleados();
            return View(oListaEmpleados);
        }

        // Muestra el formulario llamador Guardar
        public IActionResult Guardar()
        {
            return View();
        }

        // Almacena los datos del formulario Guardar
        [HttpPost]
        public IActionResult Guardar(EmpleadosModel oEmpleados)
        {
            var respuesta = _EmpleadosData.MtdAgregarEmpleados(oEmpleados);

            if (respuesta == true)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }


        // Muestra el formulario llamador Guardar
        public IActionResult Modificar(int IdEmpleado)
        {
            var oEmpleados = _EmpleadosData.MtdBuscarEmpleados(IdEmpleado);
            return View(oEmpleados);
        }

        // Almacena los datos del formulario Editar
        [HttpPost]
        public IActionResult Modificar(EmpleadosModel oEmpleados)
        {
            var respuesta = _EmpleadosData.MtdEditarEmpleados(oEmpleados);

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
        public IActionResult Eliminar(int IdEmpleado)
        {
            var oEmpleados = _EmpleadosData.MtdBuscarEmpleados(IdEmpleado);
            return View(oEmpleados);
        }

        // Envia los datos del formulario Eliminar
        [HttpPost]
        public IActionResult Eliminar(EmpleadosModel oEmpleados)
        {
            var respuesta = _EmpleadosData.MtdEliminarEmpleados(oEmpleados.IdEmpleado);

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
