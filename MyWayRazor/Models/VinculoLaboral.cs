using System;
using System.Collections.Generic;

namespace MyWayRazor.Models
{
    public partial class VinculoLaboral : IBaseEntity
    {
        public int VinculoLaboralId { get; set; }
        public int ColaboradorId { get; set; }
        public int? NumPw { get; set; }
        public int? NumCartao { get; set; }
        public DateTime? CartaoValidade { get; set; }
        public int ContratoId { get; set; }
        public DateTime? ContratoInicio { get; set; }
        public DateTime? ContratoFim { get; set; }
        public int? CargaHorariaId { get; set; }
        public int? CentroCustoId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public CargaHoraria CargaHoraria { get; set; }
        public CentroCusto CentroCusto { get; set; }
        public Colaborador Colaborador { get; set; }
        public Contrato Contrato { get; set; }
    }
}
