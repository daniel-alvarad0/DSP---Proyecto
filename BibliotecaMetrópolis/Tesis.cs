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
    
    public partial class Tesis
    {
        public int IdTesis { get; set; }
        public string Titulo { get; set; }
        public int AnnoPublic { get; set; }
        public string InstitucionEducativa { get; set; }
        public string IdPais { get; set; }
        public string PalabraBusqueda { get; set; }
    
        public virtual Pais Pais { get; set; }
    }
}
