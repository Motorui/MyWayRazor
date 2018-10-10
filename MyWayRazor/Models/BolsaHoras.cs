using System;
using System.Collections.Generic;

namespace MyWayRazor.Models
{
    public partial class BolsaHoras : IBaseEntity
    {
        public int BolsaHorasId { get; set; }
        public int ColaboradorId { get; set; }
        public DateTime BolsaHorasData { get; set; }
        public byte[] BolsaHorasTipo { get; set; }
        public int BolsaHorasHoras { get; set; }
        public int BolsaHorasMinutos { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public Colaborador Colaborador { get; set; }
    }
}
