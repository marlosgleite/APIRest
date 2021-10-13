using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Encomendum
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateDelivery { get; set; }
        public string Endereco { get; set; }
        public string condToken { get; set; }
        public string erroInterno { get; set; }
        public int totalPedidos { get; set; }
        public List<Produto> produto { get; set; }
        public Entregador entregador { get; set; }
    }
}
