using System;
using System.Collections.Generic;

namespace MyWayRazor.Models
{
    public partial class Fornecedor : IBaseEntity
    {
        public Fornecedor()
        {
            Faturas = new HashSet<Fatura>();
        }

        public int FornecedorId { get; set; }
        public string FornecedorNome { get; set; }
        public string FornecedorMorada { get; set; }
        public int? FornecedorContribuinte { get; set; }
        public int? FornecedorTelefone { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public ICollection<Fatura> Faturas { get; set; }
    }
}
