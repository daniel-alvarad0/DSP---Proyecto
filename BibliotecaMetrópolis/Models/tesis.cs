using System.ComponentModel.DataAnnotations;

namespace BibliotecaMetrópolis
{
    public class tesis
    {
        [Key]
        public int IdTesis { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Año de Publicación")]
        public int AnnoPublic { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Institución Educativa")]
        public string InstitucionEducativa { get; set; }

        [Required]
        [Display(Name = "País")]
        public int IdPais { get; set; }

        [StringLength(100)]
        [Display(Name = "Palabra de Búsqueda")]
        public string PalabraBusqueda { get; set; }


        public virtual Pais Pais { get; set; }
    }
}
