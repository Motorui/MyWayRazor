using System;
using System.Collections.Generic;

namespace MyWayRazor.Models
{
    public partial class Telefone : IBaseEntity
    {
        public int TelefoneId { get; set; }
        public int DadosPessoaisId { get; set; }
        public string TelefoneNumero { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public DadosPessoais DadosPessoais { get; set; }
    }
}
