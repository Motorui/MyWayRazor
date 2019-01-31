using MyWayRazor.Models.Tabelas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Models.Atrasos
{
    public class Atraso
    {
        [Key]
        public int AtrasoId { get; set; }

        [Display(Name ="Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAtraso { get; set; }

        [Display(Name = "Voo")]
        [MaxLength(7)]
        public string Voo { get; set; }

        //link com tabela códigos de atraso
        [Display(Name = "Código de atraso:", ShortName ="Cód.")]
        public int CodigoId { get; set; }
        public AtrasoCodigo AtrasoCodigo { get; set; }

        [Display(Name = "Refutado?")]
        public bool Refutado { get; set; }

        //link com tabela motivos de atraso
        [Display(Name = "Motivo do atraso", ShortName = "Motivo")]
        public int MotivoId { get; set; }
        public AtrasoMotivo AtrasoMotivo { get; set; }

        [Display(Name = "Resposta")]
        public string Resposta { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        [Display(Name = "Minutos imputados")]
        public int MinutosImputados { get; set; }

        //link com tabela stand
        [Display(Name = "Stand")]
        public int StandId { get; set; }
        public Stand Stand { get; set; }

        [Display(Name = "Voo de chegada")]
        public string VooArr { get; set; }

        [Display(Name = "Data voo de chegada")]
        public DateTime DataVooArr { get; set; }

        [Display(Name = "STA voo de chegada")]
        public TimeSpan StaVooArr { get; set; }

        [Display(Name = "ATA voo de chegada")]
        public TimeSpan AtaVooArr { get; set; }

        [Display(Name = "ONB voo de chegada")]
        public TimeSpan OnbVooArr { get; set; }

        [Display(Name = "WCHR voo de chegada")]
        public string WchrArr { get; set; }

        [Display(Name = "WCHS voo de chegada")]
        public string WchsArr { get; set; }

        [Display(Name = "WCHC voo de chegada")]
        public string WchcArr { get; set; }

        [Display(Name = "GSE´s Alocados à chegada")]
        public string GseArrAloc { get; set; }

        [Display(Name = "Voo de partida")]
        public string VooDep { get; set; }

        [Display(Name = "STD voo de partida")]
        public TimeSpan StdVooDep { get; set; }

        [Display(Name = "OFB voo de partida")]
        public TimeSpan OfbVooDep { get; set; }

        [Display(Name = "Begin BRD")]
        public TimeSpan BeginBrdVooDep { get; set; }

        [Display(Name = "WCHR voo de Partida")]
        public string WchrDep { get; set; }

        [Display(Name = "WCHS voo de Partida")]
        public string WchsDep { get; set; }

        [Display(Name = "WCHC voo de Partida")]
        public string WchcDep { get; set; }

        [Display(Name = "GSE´s Alocados à partida")]
        public string GseDepAloc { get; set; }

        [Display(Name = "GSE´s Operacionais")]
        public string GseOperacionais { get; set; }

        [Display(Name = "Motoristas em pausa")]
        public string GsePausaMotorista { get; set; }

        [Display(Name = "GSE´s INOP")]
        public string GseInop { get; set; }

        [Display(Name = "Motoristas Ambulift")]
        public string MotoristasAmbulift { get; set; }

        [Display(Name = "Motoristas VTA")]
        public string MotoristasVta { get; set; }

        [Display(Name = "Supervisor")]
        public Supervisor Supervisor { get; set; }
    }
}
