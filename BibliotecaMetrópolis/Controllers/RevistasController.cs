using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaMetrópolis.Controllers
{
    public class RevistasController : Controller
    {
        // GET: Revistas/revista
        public ActionResult revista()
        {
            return View();
        }
    }
}