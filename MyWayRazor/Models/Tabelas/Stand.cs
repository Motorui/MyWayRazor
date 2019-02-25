using System;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models.Tabelas
{
    public class Stand : IBaseEntity
    {
        [Key]
        public int StandId { get; set; }

        [Required]
        [Range(Int32.MaxValue, 999)]
        [Display(Name = "Stand")]
        public int StandN { get; set; }
        public bool Remoto { get; set; }

        [Display(Name = "Plataforma:")]
        public int PlataformaId { get; set; }
        public Plataforma Plataforma { get; set; }

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