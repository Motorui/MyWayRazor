using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWayRazor.Models
{
    [Table("Departamento")]
    public partial class Departamento : IBaseEntity
    {
        [Key]
        public int DepartamentoId { get; set; }
        [Required, MaxLength(15), Display(Name = "Número:", ShortName = "Núm:")]
        public int DepartamentoNumero { get; set; }
        [Required, MaxLength(150), Display(Name = "Departamento:", ShortName ="Dep:")]
        public string DepartamentoNome { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}
