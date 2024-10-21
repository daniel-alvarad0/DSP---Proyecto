using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaMetropolis.Models
{

    //Creadores del Poryecto
    //Jeremy Edenilson Flores Portillo - FP240479
    //Daniel Ernesto Alvarado Roque - AR220441
    //Edgar Josué Gómez Meléndez - GM240279
    //Lucía Milena Hernández Bonilla - HB221258


    public class Material
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Tipo { get; set; }
        public int AnnoPublicacion { get; set; }
        public string Editorial { get; set; }
        public string Institucion { get; set; }
        public List<string> PalabrasClave { get; set; }
        public string SearchText { get; set; } // Añadida esta propiedad
    }

    public class SearchViewModel
    {
        public string SearchText { get; set; }
        public string Tipo { get; set; }
        public int? Anno { get; set; }
        public List<Material> Results { get; set; }
    }
}