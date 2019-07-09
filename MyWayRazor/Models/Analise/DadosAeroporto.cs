using System;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models.Analise
{
    public class DadosAeroporto : IBaseEntity
    {
        [Key]
        public Guid ID { get; set; }
        [Display(Name = "Movimento:")]
        public string Mov { get; set; }
        [Display(Name = "Matricula:")]
        public string Reg { get; set; }
        [Display(Name = "Voo:")]
        public string Voo { get; set; }

        [Display(Name = "ETD/ETA:")]
        public DateTime? EstimatedTime { get; set; }
        [Display(Name = "STD/STA:")]
        public DateTime? ScheduleTime { get; set; }
        [Display(Name = "ATD/ATA:")]
        public DateTime? ActualTime { get; set; }
        [Display(Name = "OFB/ONB:")]
        public DateTime? BlockTime { get; set; }
        [Display(Name = "Begin BRD:")]
        public DateTime? BeginBRD { get; set; }
        [Display(Name = "End BRD:")]
        public DateTime? EndBRD { get; set; }

        [Display(Name = "ETD/ETA UTC:")]
        public DateTime? EstimatedTimeUTC { get; set; }
        [Display(Name = "STD/STA UTC:")]
        public DateTime? ScheduleTimeUTC { get; set; }
        [Display(Name = "ATD/ATA UTC:")]
        public DateTime? ActualTimeUTC { get; set; }
        [Display(Name = "OFB/ONB UTC:")]
        public DateTime? BlockTimeUTC { get; set; }
        [Display(Name = "Begin BRD UTC:")]
        public DateTime? BeginBRDUTC { get; set; }
        [Display(Name = "End BRD UTC:")]
        public DateTime? EndBRDUTC { get; set; }

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
