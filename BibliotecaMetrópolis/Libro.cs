//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BibliotecaMetrópolis
{
    using System;
    using System.Collections.Generic;
    
    public partial class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public int AnnoPublic { get; set; }
        public Nullable<int> IdEdit { get; set; }
        public string Edicion { get; set; }
        public string IdPais { get; set; }
        public string PalabraBusqueda { get; set; }
    
        public virtual Editorial Editorial { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
