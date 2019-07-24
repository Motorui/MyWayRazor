using MyWayRazor.Models.Colaboradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWayRazor.Models.Tabelas
{
    [Table("Uh")]
    public class Uh : IBaseEntity
    {
        [Key]
        public int UhId { get; set; }
        [Required, MaxLength(5), Display(Name = "Código IATA:", ShortName = "IATA:")]
        public string IATA { get; set; }

        string _uhNome;
        [Required, MaxLength(25), Display(Name = "Unidade de handling:", ShortName ="UH:")]
        public string UhNome
        {
            get => _uhNome;
            set => _uhNome = value.ToUpper();
        }

        [Display(Name = "Registo criado em:", ShortName = "Criado em:")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Registo criado por:", ShortName = "Criado por:")]
        public string CreatedBy { get; set; }
        [Display(Name = "Registo atualizado em:", ShortName = "Atualizado em:")]
        public DateTime? LastUpdatedAt { get; set; }
        [Display(Name = "Registo atualizado por:", ShortName = "Atualizado por:")]
        public string LastUpdatedBy { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}
