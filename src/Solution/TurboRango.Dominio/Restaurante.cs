﻿
namespace TurboRango.Dominio
{
    public class Restaurante : Entidade
    {
        public int? Capacidade { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public virtual Contato Contato { get; set; }
        public virtual Localizacao Localizacao { get; set; }
    }
}
