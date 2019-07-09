using MyWayRazor.Models.Colaboradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWayRazor.Models.Tabelas
{
    [Table("Departamento")]
    public partial class Departamento : IBaseEntity
    {
        [Key]
        public int DepartamentoId { get; set; }
        [Required, Display(Name = "Número:", ShortName = "Núm:")]
        public int DepartamentoNumero { get; set; }
        [Required, MaxLength(150), Display(Name = "Departamento:", ShortName ="Dep:")]
        public string DepartamentoNome { get; set; }

        [Display(Name = "Registo criado em:", ShortName = "Criado em:")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Registo criado por:", ShortName = "Criado por:")]
        public string CreatedBy { get; set; }
        [Display(Name = "Registo atualizado em:", ShortName = "Atualizado em:")]
        public DateTime? LastUpdatedAt { get; set; }
        [Display(Name = "Registo atualizado por:", ShortName = "Atualizado por:")]
        public string LastUpdatedBy { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}
