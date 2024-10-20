using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaMetropolis.ViewModels
{
    public class RecursoBase
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AnnoPublic { get; set; }
        public string Edicion { get; set; }
        public string PalabraBusqueda { get; set; }
        public int IdEdit { get; set; }
        public string IdPais { get; set; }
    }
}