using System.ComponentModel.DataAnnotations;

namespace BibliotecaMetrópolis.Models
{
    public class Paisotes
    {
        [Key] 
        public int IdPais { get; set; }

        [Required]
        [StringLength(100)] 
        public string Nombre { get; set; }
    }
}
