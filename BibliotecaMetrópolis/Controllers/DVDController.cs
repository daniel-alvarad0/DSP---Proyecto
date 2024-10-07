using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaMetrópolis.Controllers
{
    public class DVDController : Controller
    {
        // GET: DVD/discos
        public ActionResult discos()
        {
            return View();
        }

        public ActionResult DVD(string nombre)
        {
            ViewBag.Nombre = nombre;
            return View();
        }
    }
}