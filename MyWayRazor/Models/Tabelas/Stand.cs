using MyWayRazor.Models.Atrasos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Models.Tabelas
{
    public class Stand
    {
        [Key]
        public int StandId { get; set; }

        [Required]
        [Range(0, 999)]
        [Display(Name = "Stand")]
        public int NumStand { get; set; }

    }
}