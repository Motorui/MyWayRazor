using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Models
{
    public class Colaborador : IBaseEntity
    {
        [Key]
        public int ColaboradorID { get; set; }
        [Required, MaxLength(150), Display(Name = "Nome:")]
        public string Nome { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public Status Status { get; set; }
        public Uh Uh { get; set; }
    }
}