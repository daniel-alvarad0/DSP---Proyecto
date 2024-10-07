using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaMetrópolis.Controllers
{
    public class TesisController : Controller
    {
        // GET: Tesis/tesis
        // Acción para mostrar el formulario de registro
        public ActionResult Registro()
        {
            return View();
        }

        // Acción para mostrar la consulta de tesis
        public ActionResult Consulta()
        {
            return View();
        }

        // Acción para mostrar los resultados de la búsqueda de tesis
        public ActionResult Resultados()
        {
            return View();
        }
    }
}