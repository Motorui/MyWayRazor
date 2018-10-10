using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models
{
    public partial class Resumo
    {
        public int ResumoId { get; set; }
        [Display(Name = "Data:")]
        [DataType(DataType.Date)]
        public DateTime DataResumo { get; set; }

        [Display(Name = "Staff em Escala:")]
        public int StaffEscala { get; set; }

        [Display(Name = "Staff on duty:")]
        public int StaffDuty { get; set; }

        [Display(Name = "Total de assistências:")]
        public int TotalAssistencias { get; set; }

        [Display(Name = "Incumprimentos SLAs:")]
        public int IncumprimentosSla { get; set; }

        [Display(Name = "VTAs OK:")]
        public int EquipamentosOkVta { get; set; }

        [Display(Name = "AMBULIFTs OK:")]
        public int EquipamentosOkAmbulift { get; set; }

        [Display(Name = "VTAs INOP:")]
        public int EquipamentosInopVta { get; set; }

        [Display(Name = "AMBULIFTs INOP:")]
        public int EquipamentosInopAmbulift { get; set; }

        [Display(Name = "Total de voos:")]
        public int TotalVoos { get; set; }

        [Display(Name = "Atrasos imputados:")]
        public int AtrasosImputados { get; set; }

        [Display(Name = "Atrasos aceites:")]
        public int AtrasosAceites { get; set; }
    }
}
