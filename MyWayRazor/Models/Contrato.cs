using System;
using System.Collections.Generic;

namespace MyWayRazor.Models
{
    public partial class Contrato : IBaseEntity
    {
        public Contrato()
        {
            VinculoLaboral = new HashSet<VinculoLaboral>();
        }

        public int ContratoId { get; set; }
        public string ContratoNome { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public ICollection<VinculoLaboral> VinculoLaboral { get; set; }
    }
}
