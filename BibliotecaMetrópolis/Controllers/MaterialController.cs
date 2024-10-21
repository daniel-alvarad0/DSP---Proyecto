using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BibliotecaMetropolis.Models;

namespace BibliotecaMetropolis.Controllers
{
    public class SearchController : Controller
    {
        private List<Material> _materials;

        public SearchController()
        {
            InitializeMockData();
        }

        private void InitializeMockData()
        {
            _materials = new List<Material>
            {
                new Material { Id = 1, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Tipo = "Libro", AnnoPublicacion = 1967, Editorial = "Sudamericana", PalabrasClave = new List<string> { "realismo mágico", "literatura latinoamericana" } },
                new Material { Id = 2, Titulo = "El señor de los anillos", Autor = "J.R.R. Tolkien", Tipo = "Libro", AnnoPublicacion = 1954, Editorial = "Allen & Unwin", PalabrasClave = new List<string> { "fantasía", "aventura" } },
                new Material { Id = 3, Titulo = "National Geographic", Autor = "Various", Tipo = "Revista", AnnoPublicacion = 2023, Editorial = "National Geographic Society", PalabrasClave = new List<string> { "naturaleza", "ciencia", "fotografía" } },
                new Material { Id = 4, Titulo = "Análisis del impacto ambiental en Costa Rica", Autor = "María Rodríguez", Tipo = "Tesis", AnnoPublicacion = 2022, Institucion = "Universidad de Costa Rica", PalabrasClave = new List<string> { "medio ambiente", "sostenibilidad" } },
                new Material { Id = 5, Titulo = "Planeta Tierra", Autor = "BBC", Tipo = "DVD", AnnoPublicacion = 2006, PalabrasClave = new List<string> { "naturaleza", "documental" } }
            };
        }

        public ActionResult MaterialBusqueda()
        {
            var viewModel = new SearchViewModel
            {
                Results = new List<Material>()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult MaterialBusqueda(SearchViewModel model)
        {
            var results = _materials.Where(m =>
                (string.IsNullOrEmpty(model.SearchText) ||
                 m.Titulo.ToLower().Contains(model.SearchText.ToLower()) ||
                 m.Autor.ToLower().Contains(model.SearchText.ToLower()) ||
                 m.PalabrasClave.Any(k => k.ToLower().Contains(model.SearchText.ToLower()))) &&
                (model.Anno == null || m.AnnoPublicacion == model.Anno) &&
                (model.Tipo == "Todos" || m.Tipo == model.Tipo)
            ).ToList();

            model.Results = results;
            return View(model);
        }
    }
}