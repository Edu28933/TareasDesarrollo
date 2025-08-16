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

        public IActionResult Modificar(int IdSucursal)
        {
            var oSucursales = _SucursalesData.MtdBuscarSucursales(IdSucursal);
            return View(oSucursales);
        }
        // Almacena los datos del formulario Guardar
        [HttpPost]
        public IActionResult Modificar(SucursalesModel oSucursales)
        {
            var respuesta = _SucursalesData.MtdEditarSucursales(oSucursales);

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

        public IActionResult Eliminar(int IdSucursal)
        {
            var oSucursales = _SucursalesData.MtdBuscarSucursales(IdSucursal);
            return View(oSucursales);
        }


        // Envia los datos del formulario Eliminar
        [HttpPost]
        public IActionResult Eliminar(SucursalesModel oSucursal)
        {
            var respuesta = _SucursalesData.MtdEliminarSucursales(oSucursal.IdSucursal);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(oSucursal);
            }
        }



    }
}
