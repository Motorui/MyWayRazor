using System;
using System.Collections.Generic;

namespace MyWayRazor.Models
{
    public partial class CargaHoraria : IBaseEntity
    {
        public CargaHoraria()
        {
            VinculoLaboral = new HashSet<VinculoLaboral>();
        }

        public int CargaHorariaId { get; set; }
        public string CargaHorariaDescricao { get; set; }
        public int CargaHorariaHoras { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public ICollection<VinculoLaboral> VinculoLaboral { get; set; }
    }
}
