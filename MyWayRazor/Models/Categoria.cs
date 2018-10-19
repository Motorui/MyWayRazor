using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWayRazor.Models
{
    [Table("Categoria")]
    public class Categoria : IBaseEntity
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required, MaxLength(50), Display(Name = "Categoria:", ShortName = "Cat:")]
        public string CategoriaNome { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}