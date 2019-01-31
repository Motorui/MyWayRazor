using System;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Models.Analise
{
    public class AssistenciasPRM
    {
        [Key]
        public int ID { get; set; }
        public string Aeroporto { get; set; }
        public string Msg { get; set; }
        public string Notif { get; set; }
        public DateTime Data { get; set; }
        public string Voo { get; set; }
        public string Mov { get; set; }
        public string OrigDest { get; set; }
        public string Pax { get; set; }
        public string SSR { get; set; }
        public string AC { get; set; }
        public string Stand { get; set; }
        public string Exit { get; set; }
        public string CkIn { get; set; }
        public string Gate { get; set; }
        public string Transferencia { get; set; }
    }
}
