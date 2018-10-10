using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Models
{
    [Table("Uh")]
    public class Uh : IBaseEntity
    {
        [Key]
        public int UhID { get; set; }
        [Required, MaxLength(5), Display(Name = "Código IATA:")]
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
