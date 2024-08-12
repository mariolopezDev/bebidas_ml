using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bebidas_ML.Models
{
    public class Bebida
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ?Descripcion { get; set; }

        [Required]
        [MaxLength(50)]
        public string ?Tamano { get; set; }

        [Required]
        [MaxLength(50)]
        public string ?PaisOrigen { get; set; }

        public IList<int> ?TiposBebidaIds { get; set; }
    }
}
