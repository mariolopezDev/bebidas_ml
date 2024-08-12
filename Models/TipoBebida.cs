using System.ComponentModel.DataAnnotations;

namespace Bebidas_ML.Models
{
    public class TipoBebida
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ?Descripcion { get; set; }
    }
}
