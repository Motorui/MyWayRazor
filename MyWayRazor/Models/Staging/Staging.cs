using MyWayRazor.Models.Tabelas;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models.Staging
{
    public class Staging : IBaseEntity
    {
        [Key]
        public int ID { get; set; }

        public string Msg { get; set; }
        public string Notif { get; set; }
        public DateTime Data { get; set; }
        public string Voo { get; set; }
        public string Mov { get; set; }
        public string OrigemDestino { get; set; }
        public string Pax { get; set; }
        public string Ssr { get; set; }
        public string AirCraft { get; set; }
        public string Stand { get; set; }
        public string CheckIn { get; set; }
        public string Gate { get; set; }
        public string Remark { get; set; }
        public DateTime Etd { get; set; }
        public DateTime Antecipar { get; set; }
        public DateTime Horario { get; set; }

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
