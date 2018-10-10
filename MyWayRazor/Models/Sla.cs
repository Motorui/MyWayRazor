using System;
using System.Collections.Generic;

namespace MyWayRazor.Models
{
    public partial class Sla
    {
        public int SlaId { get; set; }
        public DateTime DataSla { get; set; }
        public int PcMenorIgual10 { get; set; }
        public int PcMaior10MenorIgual20 { get; set; }
        public int PcMaior20MenorIgual30 { get; set; }
        public int PcMaior30 { get; set; }
        public int PsMenorIgual25 { get; set; }
        public int PsMaior25MenorIgual35 { get; set; }
        public int PsMaior35MenorIgual45 { get; set; }
        public int PsMaior45 { get; set; }
        public int CcMenorIgual5 { get; set; }
        public int CcMaior5MenorIgual10 { get; set; }
        public int CcMaior10MenorIgual20 { get; set; }
        public int CcMaior20 { get; set; }
        public int CsMenorIgual25 { get; set; }
        public int CsMaior25MenorIgual35 { get; set; }
        public int CsMaior35MenorIgual45 { get; set; }
        public int CsMaior45 { get; set; }
        public int C90MenorIgual15 { get; set; }
        public int C90Maior15MenorIgual20 { get; set; }
        public int C90Maior20MenorIgual30 { get; set; }
        public int C90Maior30 { get; set; }
    }
}
