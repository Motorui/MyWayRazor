using System;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models
{
    public class Assistencia
    {
        [Key]
        public int AssistenciaId { get; set; }

        [Required, MaxLength(6), Display(Name = "Tipo Msg:", ShortName = "Msg:")]
        public string TipoMensagem { get; set; }

        [Required, MaxLength(4), Display(Name = "Aeroporto:")]
        public string Aeroporto { get; set; }

        [Required, MaxLength(6), Display(Name = "Notificação:", ShortName = "Notif:")]
        public string Notificacao { get; set; }

        [Required, Display(Name = "Horário:")]
        public DateTime HoraVoo { get; set; }

        [Display(Name = "Hora de contacto:", ShortName = "Contacto:")]
        public DateTime HoraContacto { get; set; }

        [Required, Display(Name = "Hora de início:", ShortName = "Início:")]
        public DateTime HoraInicio { get; set; }

        [Required, Display(Name = "Hora de fim:", ShortName = "Fim:")]
        public DateTime HoraFim { get; set; }

        [Required, MaxLength(10), Display(Name = "Voo:")]
        public string Voo { get; set; }

        [Required, MaxLength(1), Display(Name = "Movimento:", ShortName = "Mov:")]
        public string Movimento { get; set; }

        [Required, MaxLength(6), Display(Name = "Tipo Msg:", ShortName = "Msg:")]
        public string OrigemDestino { get; set; }

        [Required, MaxLength(150), Display(Name = "Nome do passageiro:", ShortName = "PAX:")]
        public string NomePax { get; set; }

        [Required, MaxLength(30), Display(Name = "Tipologia:", ShortName = "SSR:")]
        public string Tipologia { get; set; }

        [Required, MaxLength(3), Display(Name = "Aeronave:", ShortName = "AC:")]
        public string Aircraft { get; set; }

        [Required, MaxLength(3), Display(Name = "Stand:")]
        public string Stand { get; set; }

        [MaxLength(1), Display(Name = "Saída:", ShortName = "Exit:")]
        public string Exit { get; set; }

        [MaxLength(10), Display(Name = "CheckIn:", ShortName = "CkIn:")]
        public string CheckIn { get; set; }

        [MaxLength(5), Display(Name = "Porta:", ShortName = "Gate:")]
        public string Gate { get; set; }

        [MaxLength(1), Display(Name = "Transferençia:", ShortName = "Transf:")]
        public string Transferencia { get; set; }

        [MaxLength(250), Display(Name = "Equipamentos:", ShortName = "Equip:")]
        public string Equipamentos { get; set; }
    }
}
