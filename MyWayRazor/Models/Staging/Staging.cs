using MyWayRazor.Models.Tabelas;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models.Staging
{
    public class Staging : IBaseEntity
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Mensagem:")]
        public string Msg { get; set; }
        [Display(Name = "Notificação:")]
        public string Notif { get; set; }
        [Required]
        [Display(Name = "Data:")]
        public DateTime Data { get; set; }
        [Required]
        [Display(Name = "Voo:")]
        public string Voo { get; set; }
        [Display(Name = "Movimento:")]
        public string Mov { get; set; }
        [Display(Name = "Origem/Destino:")]
        public string OrigemDestino { get; set; }
        [Required]
        [Display(Name = "Passageiro:")]
        public string Pax { get; set; }
        [Display(Name = "Serviçe Request:")]
        public string Ssr { get; set; }
        [Display(Name = "Aeronave:")]
        public string AirCraft { get; set; }
        [Display(Name = "Stand:")]
        public string Stand { get; set; }
        [Display(Name = "Check-in:")]
        public string CheckIn { get; set; }
        [Display(Name = "Porta:")]
        public string Gate { get; set; }
        [Display(Name = "Observações:")]
        public string Remark { get; set; }
        [Display(Name = "Estimated Time Departure:")]
        public DateTime Etd { get; set; }
        [Display(Name = "Hora de embarque:")]
        public DateTime HoraEmbarque { get; set; }
        [Display(Name = "Saída da Staging Area:")]
        public DateTime SaidaStaging { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public bool Destino { get; set; }
        public bool Alerta { get; set; }
        public string Observacao { get; set; }


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
