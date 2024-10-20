using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca_Metropolis.Models.Repository;
using BibliotecaMetropolis.ViewModels;
using BibliotecaMetropolis.ViewModels.Repository;


namespace BibliotecaMetropolis.Controllers
{
    public class BuscarController : Controller
    {
        private RecursoRepository recursoRepository = new RecursoRepository();        // GET: Buscar
        public ActionResult BuscarRecurso()
        {
            var modeloRecurso = new RecursoRepository();
            var recursos = modeloRecurso.ListarRecurso();

            mostrarSelect();

            return View(recursos);
        }

        [HttpPost]
        public ActionResult BuscarRecurso(string tipoRecurso, string antiguedad, string autor, string editorial, string palabraClave, string pais)
        {
            var recursos = recursoRepository.BuscarRecursos(tipoRecurso, antiguedad, autor, editorial, palabraClave, pais);

            mostrarSelect();
            return View(recursos);
        }

        //Metodo para mostrar los select
        public void mostrarSelect()
        {

            var modeloAutor = new AutorRepository();
            var autores = modeloAutor.Dropdown();

            var modeloPais = new PaisRepository();
            var paises = modeloPais.Dropdown();

            var modeloEditorial = new EditorialRepository();
            var editoriales = modeloEditorial.Dropdown();

            // Pasar datos a la vista usando ViewBag
            ViewBag.Paises = new SelectList(paises, "Value", "Text");
            ViewBag.Editoriales = new SelectList(editoriales, "Value", "Text");
            ViewBag.Autores = new SelectList(autores, "Value", "Text");
        }


    }
}