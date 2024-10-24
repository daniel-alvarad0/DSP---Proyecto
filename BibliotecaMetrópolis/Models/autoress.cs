using System.ComponentModel.DataAnnotations;

namespace BibliotecaMetrópolis.Models
{
    public class autoress
    {
        
        public int IdAutor { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres.")]
        public string Apellido { get; set; }
    }
}
