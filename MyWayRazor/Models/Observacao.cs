using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models
{
    public partial class Observacao : IBaseEntity
    {
        public int ObservacaoId { get; set; }
        public int ColaboradorId { get; set; }
        public string ObservacaoTitulo { get; set; }
        public string Texto { get; set; }

        [Display(Name = "Registo criado em:", ShortName = "Criado em:")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Registo criado por:", ShortName = "Criado por:")]
        public string CreatedBy { get; set; }
        [Display(Name = "Registo atualizado em:", ShortName = "Atualizado em:")]
        public DateTime? LastUpdatedAt { get; set; }
        [Display(Name = "Registo atualizado por:", ShortName = "Atualizado por:")]
        public string LastUpdatedBy { get; set; }

        public Colaborador Colaborador { get; set; }
    }
}
