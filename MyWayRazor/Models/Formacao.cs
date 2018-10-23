using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Registo criado em:", ShortName = "Criado em:")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Registo criado por:", ShortName = "Criado por:")]
        public string CreatedBy { get; set; }
        [Display(Name = "Registo atualizado em:", ShortName = "Atualizado em:")]
        public DateTime? LastUpdatedAt { get; set; }
        [Display(Name = "Registo atualizado por:", ShortName = "Atualizado por:")]
        public string LastUpdatedBy { get; set; }

        public ICollection<FormacaoColaborador> FormacoesColaborador { get; set; }
    }
}
