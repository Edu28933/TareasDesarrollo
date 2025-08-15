using Microsoft.AspNetCore.Mvc;
using ProyectoHotel.Data;
using ProyectoHotel.Models; 

namespace ProyectoHotel.Controllers
{
    public class SucursalesController : Controller
    {
        SucursalesData _SucursalesData = new SucursalesData();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listar()
        {
            var oListaSucursales  = _SucursalesData.MtdConsultarSucursales();
            return View(oListaSucursales);
        }


        // Muestra el formulario llamador Guardar
        public IActionResult Guardar()
        {
            return View();
        }

        // Almacena los datos del formulario Guardar
        [HttpPost]
        public IActionResult Guardar(SucursalesModel oSucursales)
        {
            var respuesta = _SucursalesData.MtdAgregarSucursales(oSucursales);

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
