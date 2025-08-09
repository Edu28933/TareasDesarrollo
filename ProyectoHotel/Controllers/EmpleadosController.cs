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

    }
}
