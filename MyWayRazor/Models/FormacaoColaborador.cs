using System;
using System.Collections.Generic;

namespace MyWayRazor.Models
{
    public partial class FormacaoColaborador : IBaseEntity
    {
        public int FormacaoColaboradorId { get; set; }
        public int FormacaoId { get; set; }
        public int ColaboradorId { get; set; }
        public DateTime FormacaoData { get; set; }
        public DateTime FormacaoCaducidade { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public Colaborador Colaborador { get; set; }
        public Formacao Formacao { get; set; }
    }
}
