using System.ComponentModel.DataAnnotations;

namespace BibliotecaMetrópolis.Models
{
    public class dvdss
    {
       
        public int IdDVD { get; set; }
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(200, ErrorMessage = "El título no puede tener más de 200 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El año de publicación es obligatorio.")]
        [Range(1900, 2100, ErrorMessage = "El año de publicación debe estar entre 1900 y 2100.")]
        public int AnnoPublic { get; set; }
        public int IdEdit { get; set; }
        public int IdPais { get; set; }

        [StringLength(100, ErrorMessage = "La palabra de búsqueda no puede tener más de 100 caracteres.")]
        public string PalabraBusqueda { get; set; }
        public virtual Editoriales Editorial { get; set; }

        public virtual Pais Pais { get; set; }
    }
}
