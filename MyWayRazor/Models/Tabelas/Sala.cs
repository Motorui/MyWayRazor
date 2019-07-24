using System;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models.Tabelas
{
    public class Sala : IBaseEntity
    {
        [Key]
        public Guid SalaID { get; set; }

        string _salaNome;
        [Required, MaxLength(50), Display(Name = "Sala:", ShortName = "S:")]
        public string SalaNome
        {
            get => _salaNome;
            set => _salaNome = value.ToUpper();
        }

        [Required, Display(Name = "Capacidade:")]
        public int Capacidade { get; set; }

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
