using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Disqueria.Models
{
    [Table("Canciones")]
    public class Cancion
    {
        [Key]
        public int CancionID { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "El título de la canción es obligatorio.")]
        [Column("Cancion")]
        [Display(Name = "Título")]
        public string Nombre { get; set; }
        public string Duracion { get; set; }
    }
}
