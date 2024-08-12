using System.Collections.Generic;

namespace Bebidas_ML.Models
{
    public class BebidaDto
    {
        public int Id { get; set; }
        public string ?Descripcion { get; set; }
        public string ?Tamano { get; set; }
        public string ?PaisOrigen { get; set; }
        public List<TipoBebidaDto> ?TiposBebida { get; set; }
    }

    public class TipoBebidaDto
    {
        public int Id { get; set; }
        public string ?Descripcion { get; set; }
    }
}
