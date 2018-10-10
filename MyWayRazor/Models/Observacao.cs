using System;
using System.Collections.Generic;

namespace MyWayRazor.Models
{
    public partial class Observacao : IBaseEntity
    {
        public int ObservacaoId { get; set; }
        public int ColaboradorId { get; set; }
        public string ObservacaoTitulo { get; set; }
        public string Texto { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public Colaborador Colaborador { get; set; }
    }
}
