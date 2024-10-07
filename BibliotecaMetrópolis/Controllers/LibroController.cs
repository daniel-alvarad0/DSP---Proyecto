using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaMetrópolis.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro/Registrar
        public ActionResult Registrar()
        {
            return View();
        }
    }
}