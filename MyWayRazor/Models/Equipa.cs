using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWayRazor.Models
{
    [Table("Equipa")]
    public class Equipa : IBaseEntity
    {
        [Key]
        public int EquipaId { get; set; }
        [Required, MaxLength(5), Display(Name = "Equipa:")]
        public string EquipaNome { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}