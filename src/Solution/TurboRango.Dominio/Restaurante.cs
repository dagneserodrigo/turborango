﻿
using System.Collections.Generic;
namespace TurboRango.Dominio
{
    public class Restaurante : Entidade
    {
        public int? Capacidade { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public Contato Contato { get; set; }
        public Localizacao Localizacao { get; set; }
        public PratoDoDia PratoDoDia { get; set; }
    }
}
