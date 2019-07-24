using MyWayRazor.Models.Formacoes;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models.Tabelas
{
    public class Formador : IBaseEntity
    {
        [Key]
        public Guid FormadorID { get; set; }

        string _formadorNome;
        [Required, MaxLength(50), Display(Name = "Formador:", ShortName = "For:")]
        public string FormadorNome
        {
            get => _formadorNome;
            set => _formadorNome = value.ToUpper();
        }

        //link com tabela formações
        [Display(Name = "Formação:", ShortName = "F.:")]
        public Guid FormacaoId { get; set; }
        public Formacao Formacao { get; set; }

        [Display(Name = "Registo criado em:", ShortName = "Criado em:")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Registo criado por:", ShortName = "Criado por:")]
        public string CreatedBy { get; set; }
        [Display(Name = "Registo atualizado em:", ShortName = "Atualizado em:")]
        public DateTime? LastUpdatedAt { get; set; }
        [Display(Name = "Registo atualizado por:", ShortName = "Atualizado por:")]
        public string LastUpdatedBy { get; set; }
    }
}
