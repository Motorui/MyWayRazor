using System;
using System.Collections.Generic;

namespace MyWayRazor.Models
{
    public partial class Formacao : IBaseEntity
    {
        public Formacao()
        {
            FormacoesColaborador = new HashSet<FormacaoColaborador>();
        }

        public int FormacaoId { get; set; }
        public string FormacaoNome { get; set; }
        public int FormacaoValidade { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public ICollection<FormacaoColaborador> FormacoesColaborador { get; set; }
    }
}
