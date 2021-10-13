using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }
}
