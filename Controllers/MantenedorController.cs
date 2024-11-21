using CRUDCORE.Datos;
using CRUDCORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        EmpresaDatos _EmpresaDatos = new EmpresaDatos();

        public IActionResult Listar()
        {
            // LA VISTA MOSTRARÁ UNA LISTA DE ALUMNOS
            var oLista = _EmpresaDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            // MÉTODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(EmpresaModel oEmpresa)
        {
            // MÉTODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _EmpresaDatos.Guardar(oEmpresa);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int Cif)  // Cambio aquí: Cif debe ser int
        {
            var oEmpresa = _EmpresaDatos.Obtener(Cif);  // Asegúrate de pasar int
            return View(oEmpresa);
        }

        [HttpPost]
        public IActionResult Editar(EmpresaModel oEmpresa)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _EmpresaDatos.Editar(oEmpresa);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Cif)  // Cambio aquí: Cif debe ser int
        {
            var oEmpresa = _EmpresaDatos.Obtener(Cif);  // Asegúrate de pasar int
            return View(oEmpresa);
        }

        [HttpPost]
        public IActionResult Eliminar(EmpresaModel oEmpresa)
        {
            var respuesta = _EmpresaDatos.Eliminar(oEmpresa.Cif.ToString());  // Aquí, Cif es un int

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
