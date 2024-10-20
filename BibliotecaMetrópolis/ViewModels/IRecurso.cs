using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaMetrópolis.ViewModels
{
    public interface IRecurso
    {
        int Id { get; set; }
        string Titulo { get; set; }
        int AnnoPublic { get; set; }
        string Edicion { get; set; }
        string PalabraBusqueda { get; set; }
        Editorial Editorial { get; set; }
        Pais Pais { get; set; }
        ICollection<AutoresRecursos> AutoresRecursos { get; set; }
    }
}
