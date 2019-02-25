using System;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models.Tabelas
{
    public class Porta : IBaseEntity
    {
        [Key]
        public int PortaID { get; set; }

        [Required]
        [Display(Name = "Porta")]
        public string PortaNum { get; set; }

        [Display(Name = "Deslocação")]
        public int PortaTempo { get; set; }

        //bool Schengen 0 NãoSchengen 1
        [Display(Name = "Schengen?")]
        public bool Schengen { get; set; }

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
