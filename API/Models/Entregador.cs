using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Entregador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Placa { get; set; }
    }
}
