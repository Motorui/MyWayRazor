using System;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models.Colaboradores
{
    public partial class Telefone : IBaseEntity
    {
        public int TelefoneId { get; set; }
        public int DadosPessoaisId { get; set; }
        public string TelefoneNumero { get; set; }

        [Display(Name = "Registo criado em:", ShortName = "Criado em:")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Registo criado por:", ShortName = "Criado por:")]
        public string CreatedBy { get; set; }
        [Display(Name = "Registo atualizado em:", ShortName = "Atualizado em:")]
        public DateTime? LastUpdatedAt { get; set; }
        [Display(Name = "Registo atualizado por:", ShortName = "Atualizado por:")]
        public string LastUpdatedBy { get; set; }

        public DadosPessoais DadosPessoais { get; set; }
    }
}
