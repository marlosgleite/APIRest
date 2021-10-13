using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class RelEncomendaProduto
    {
        public int Id { get; set; }
        public int IdEncomenda { get; set; }
        public int IdProduto { get; set; }
        public int IdEntregador { get; set; }
    }
}
