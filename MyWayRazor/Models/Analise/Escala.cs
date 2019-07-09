using System;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models.Analise
{
    public class Escala : IBaseEntity
    {
        [Key]
        public Guid ID { get; set; }
        [Display(Name = "Colaborador:")]
        public string Nome { get; set; }
        [Display(Name = "Numero:")]
        public int Numero { get; set; }
        [Display(Name = "Equipa:")]
        public string Equipa { get; set; }
        [Display(Name = "Função:")]
        public string Funcao { get; set; }
        [Display(Name = "Dia:")]
        public DateTime Dia { get; set; }
        [Display(Name = "Horário:")]
        public string Horario { get; set; }
        [Display(Name = "Entrada:")]
        public DateTime HoraEntrada { get; set; }
        [Display(Name = "Saída:")]
        public DateTime HoraSaida { get; set; }

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
