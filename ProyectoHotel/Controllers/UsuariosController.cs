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

        // Lista de usuarios
        public IActionResult Listar()
        {
            var oListaUsuarios = _UsuariosData.MtdConsultarUsuarios();
            return View(oListaUsuarios);
        }

        // Muestra el formulario llamador Guardar
        public IActionResult Guardar()
        {
            return View();
        }

        // Almacena los datos del formulario Guardar
        [HttpPost]
        public IActionResult Guardar(UsuariosModel oUsuarios)
        {
            var respuesta = _UsuariosData.MtdAgregarUsuarios(oUsuarios);

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
        public IActionResult Modificar(int IdUsuario)
        {
            var oUsuarios = _UsuariosData.MtdBuscarUsuarios(IdUsuario);
            return View(oUsuarios);
        }

        // Almacena los datos del formulario Modificar
        [HttpPost]
        public IActionResult Modificar(UsuariosModel oUsuarios)
        {
            var respuesta = _UsuariosData.MtdEditarUsuarios(oUsuarios);

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
        public IActionResult Eliminar(int IdUsuario)
        {
            var oUsuarios = _UsuariosData.MtdBuscarUsuarios(IdUsuario);
            return View(oUsuarios);
        }

        // Envía los datos del formulario Eliminar
        [HttpPost]
        public IActionResult Eliminar(UsuariosModel oUsuarios)
        {
            var respuesta = _UsuariosData.MtdEliminarUsuarios(oUsuarios.IdUsuario);

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
