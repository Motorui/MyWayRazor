using System;
using System.Collections.Generic;

namespace MyWayRazor.Models
{
    public partial class CentroCusto
    {
        public CentroCusto()
        {
            Faturas = new HashSet<Fatura>();
            VinculoLaboral = new HashSet<VinculoLaboral>();
        }

        public int CentroCustoId { get; set; }
        public int CentroCustoNum { get; set; }
        public string CentroCustoNome { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public ICollection<Fatura> Faturas { get; set; }
        public ICollection<VinculoLaboral> VinculoLaboral { get; set; }
    }
}
