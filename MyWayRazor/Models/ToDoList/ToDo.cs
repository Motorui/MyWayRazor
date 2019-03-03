using System;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models.ToDoList
{
    public class ToDo : IBaseEntity
    {
        [Key]
        public int ToDoId { get; set; }
        [Required, Display(Name = "Titulo:")]
        public string ToDoTittle { get; set; }
        [Required, Display(Name = "Texto:")]
        public string ToDoText { get; set; }
        [Display(Name = "Feito?:")]
        public bool Done { get; set; }

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
