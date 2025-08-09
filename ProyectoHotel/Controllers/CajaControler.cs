using Microsoft.AspNetCore.Mvc;
using ProyectoHotel.Models;
using ProyectoHotel.Data;

namespace ProyectoHotel.Controllers
{
    public class CajaController : Controller
    {
        CajaData _CajaData = new CajaData();

        public IActionResult Listar()
        {
            var oListaCaja = _CajaData.MtdConsultarCaja();
            return View(oListaCaja);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(CajaModel oCaja)
        {
            var respuesta = _CajaData.MtdAgregarCaja(oCaja);

            if (respuesta == true)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Modificar(int IdCaja)
        {
            var oCaja = _CajaData.MtdBuscarCaja(IdCaja);
            return View(oCaja);
        }

        [HttpPost]
        public IActionResult Modificar(CajaModel oCaja)
        {
            var respuesta = _CajaData.MtdEditarCaja(oCaja);

            if (respuesta == true)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int IdCaja)
        {
            var oCaja = _CajaData.MtdBuscarCaja(IdCaja);
            return View(oCaja);
        }

        [HttpPost]
        public IActionResult Eliminar(CajaModel oCaja)
        {
            var respuesta = _CajaData.MtdEliminarCaja(oCaja.IdCaja);

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
