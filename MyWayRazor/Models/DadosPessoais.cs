using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Registo criado em:", ShortName = "Criado em:")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Registo criado por:", ShortName = "Criado por:")]
        public string CreatedBy { get; set; }
        [Display(Name = "Registo atualizado em:", ShortName = "Atualizado em:")]
        public DateTime? LastUpdatedAt { get; set; }
        [Display(Name = "Registo atualizado por:", ShortName = "Atualizado por:")]
        public string LastUpdatedBy { get; set; }

        public Colaborador Colaborador { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}
