using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Models.Atrasos
{
    public class Motivo
    {
        [Key]
        public int MotivoId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Motivo do atraso", ShortName = "Motivo")]
        public string MotivoAtraso { get; set; }

    }
}