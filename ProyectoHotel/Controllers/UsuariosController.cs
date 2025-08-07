using Microsoft.AspNetCore.Mvc;
using ProyectoHotel.Models;
using ProyectoHotel.Data;

namespace ProyectoHotel.Controllers
{
    public class UsuariosController : Controller
    {
        UsuariosData _UsuariosData = new UsuariosData();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listar()
        {
            var oListaUsuarios = _UsuariosData.MtdConsultarUsuarios();
            return View(oListaUsuarios);
        }

    }
}
