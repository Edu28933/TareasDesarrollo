using Microsoft.AspNetCore.Mvc;
using ProyectoHotel.Models;
using ProyectoHotel.Data;

namespace ProyectoHotel.Controllers
{

    public class CajaController : Controller
    {
        CajaData _CajaData = new CajaData();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listar()
        {
            var oListaCaja = _CajaData.MtdConsultarCaja();
            return View(oListaCaja);
        }

    }
}
