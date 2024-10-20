using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaMetropolis.ViewModels
{
    public class RecursosMostrar
    {
        public int IdRec { get; set; }
        public string Titulo { get; set; }
        public int AnnoPublic { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
        public string Pais { get; set; }
        public string AutorPrincipal { get; set; }
        public List<string> AutoresSecundarios { get; set; }
        public string PalabrasClave { get; set; }
    }
}
