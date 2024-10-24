using System.ComponentModel.DataAnnotations;

namespace BibliotecaMetrópolis
{
    public class revistass
    {
        [Key]
        public int IdRevista { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Año de Publicación")]
        public int AnnoPublic { get; set; }

        [Required]
        [Display(Name = "Editorial")]
        public int IdEdit { get; set; }

        [Required]
        [StringLength(50)]
        public string Edicion { get; set; }

        [Required]
        [Display(Name = "País")]
        public int IdPais { get; set; }

        [StringLength(100)]
        [Display(Name = "Palabra de Búsqueda")]
        public string PalabraBusqueda { get; set; }

        public virtual Editorial Editorial { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
