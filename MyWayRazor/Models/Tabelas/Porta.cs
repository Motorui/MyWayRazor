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

        [Required]
        [Display(Name = "Deslocação")]
        public int PortaTempo { get; set; }

        //bool Schengen True NãoSchengen False
        [Required]
        [Display(Name = "Schengen?")]
        public bool Schengen { get; set; }

        //bool Terminal1 True Terminal2 False
        [Required]
        [Display(Name = "Terminal1?")]
        public bool Terminal { get; set; }

        //bool Remoto True Remoto False
        [Required]
        [Display(Name = "Remoto?")]
        public bool Remoto { get; set; }

        [Display(Name = "Pier")]
        public int PierID { get; set; }
        public Pier Pier { get; set; }

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
