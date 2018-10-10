using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWayRazor.Models
{
    public partial class Fatura : IBaseEntity
    {
        public int FaturaId { get; set; }
        public int? CentroCustoId { get; set; }
        public int FornecedorId { get; set; }
        public byte[] FaturaTipo { get; set; }
        public string FaturaNum { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FaturaValor { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public CentroCusto CentroCusto { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
