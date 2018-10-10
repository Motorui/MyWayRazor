using System;
using System.Collections.Generic;

namespace MyWayRazor.Models
{
    public partial class DadosPessoais : IBaseEntity
    {
        public DadosPessoais()
        {
            Emails = new HashSet<Email>();
            Telefones = new HashSet<Telefone>();
        }

        public int DadosPessoaisId { get; set; }
        public int ColaboradorId { get; set; }
        public string ColaboradorIdentificacao { get; set; }
        public DateTime? ColaboradorIdentificacaoValidade { get; set; }
        public string DadosPessoaisMorada { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public Colaborador Colaborador { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}
