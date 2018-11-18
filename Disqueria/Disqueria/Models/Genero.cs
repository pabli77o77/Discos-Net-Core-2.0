using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disqueria.Models
{
    [Table("Generos")]
    public class Genero
    {
        [Key]
        [Display(Name ="ID")]
        public int GeneroID { get; set; }
        [MaxLength]
        [Required(ErrorMessage ="Nombre obligatorio")]
        [Column("Genero")]
        [Display(Name = "Genero")]
        public string Nombre { get; set; }
    }
}