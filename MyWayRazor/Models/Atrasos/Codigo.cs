using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Models.Atrasos
{
    public class Codigo
    {
        [Key]
        public int CodigoId {get; set;}

        [Required]
        [StringLength(25)]
        [Display(Name = "Código Atraso", ShortName ="Cód.")]
        public string CodigoAtraso { get; set; }

    }
}
