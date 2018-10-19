using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWayRazor.Models
{
    [Table("Uh")]
    public class Uh : IBaseEntity
    {
        [Key]
        public int UhId { get; set; }
        [Required, MaxLength(5), Display(Name = "Código IATA:", ShortName = "IATA:")]
        public string IATA { get; set; }
        [Required, MaxLength(25), Display(Name = "Unidade de handling:", ShortName ="UH:")]
        public string UhNome { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}
