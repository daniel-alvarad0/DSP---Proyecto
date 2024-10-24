using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaMetrópolis.Models

{
    public class Librotes
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public int AnnoPublic { get; set; }
        public string Edicion { get; set; }
        public string PalabraBusqueda { get; set; }
        public int IdEdit { get; set; }
        public int IdPais { get; set; }
    }

    public class Editoriales
    {
        public int IdEdit { get; set; }
        public string Nombre { get; set; }
    }

    public class Pais
    {
        public int IdPais { get; set; }
        public string Nombre { get; set; }
    }
}
