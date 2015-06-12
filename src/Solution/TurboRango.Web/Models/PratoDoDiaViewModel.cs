using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurboRango.Web.Models
{
    public class PratoDoDiaViewModel
    {
        public string Nome { get; set; }
        public string Ingredientes { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string Descricao { get; set; }
        public int Restaurante { get; set; }
    }
}