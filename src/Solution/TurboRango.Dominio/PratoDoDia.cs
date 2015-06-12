using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboRango.Dominio
{
    public class PratoDoDia : Entidade
    {
        public string Nome { get; set; }
        public string  Ingredientes { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string Descricao { get; set; }
    }
}
