using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaMetrópolis.Models
{
    public class editorialess
    {
        public int IdEdit { get; set; }
        [Required(ErrorMessage = "El nombre de la editorial es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }
        public virtual ICollection<dvdss> DVDs { get; set; }
    }
}
