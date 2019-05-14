using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;
using MyWayRazor.Models.Tabelas;
using SmartBreadcrumbs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Analise
{
    [Breadcrumb("PMR Remoto", FromPage = typeof(IndexModel))]
    public class PmrRemotoModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public PmrRemotoModel(ApplicationDbContext context)
        {
            db = context;
        }

        public DateTime Hoje = DateTime.UtcNow.Date;
        private List<string> ExitSchengen = new List<string>() { "E", "S" };
        public List<string> SaidaSchengen { get; private set; }

        public IList<AssistenciasPRM> AssistenciasPRMs { get; set; }
        public IList<Porta> Portas { get; set; }
        public IList<Stand> Stands { get; set; }
        public IList<Parametro> Parametros { get; set; }

        public List<int> PierSul { get; private set; }
        public List<int> PierNorte { get; private set; }
        public List<int> Pier14 { get; private set; }
        public List<int> Remotos { get; private set; }
        public List<string> GateSchengen { get; private set; }
        public List<string> GateNSchengen { get; private set; }
        public List<string> GateT2 { get; private set; }

        public int TotalPmr { get; private set; }
        public int TotalDep { get; private set; }
        public int TotalArr { get; private set; }

        public int TotalDepS { get; private set; }
        public int TotalDepN { get; private set; }
        public int TotalDepT2 { get; private set; }

        public int TotalArrSchengen { get; private set; }
        public int TotalArrNSchengen { get; private set; }

        public int TotalTranSchengen { get; private set; }
        public int TotalTranNSchengen { get; private set; }

        public async Task OnGetAsync()
        {

            AssistenciasPRMs = await db.AssistenciasPRMS.Where(d => d.Data.Date == Hoje).ToListAsync();
            SaidaSchengen = ExitSchengen.ToList();
            Portas = await db.Portas.ToListAsync();
            Stands = await db.Stands.ToListAsync();
            Parametros = await db.Parametros.ToListAsync();

            PierSul = StandList(1, false).Select(v => v.StandN).ToList();
            PierNorte = StandList(2, false).Select(v => v.StandN).ToList();
            Pier14 = StandList(3, false).Select(v => v.StandN).ToList();
            Remotos = StandList(0, true).Select(v => v.StandN).ToList();

            GateSchengen = GateList(true, true, false).Select(v => v.PortaNum).ToList();
            GateNSchengen = GateList(false, true, false).Select(v => v.PortaNum).ToList();
            GateT2 = GateList(false, false, true).Select(v => v.PortaNum).ToList();

            TotalPmr = TotaisPmr(true, "");
            TotalDep = TotaisPmr(false, "D");
            TotalArr = TotaisPmr(false, "A");

            TotalDepS = TotalPmrDep(GateSchengen);
            TotalDepN = TotalPmrDep(GateNSchengen);
            TotalDepT2 = TotalPmrDep(GateT2);

            TotalArrSchengen = TotalPmrArr(true);
            TotalArrNSchengen = TotalPmrArr(false);

            TotalTranSchengen = TotalPmrTrans("S");
            TotalTranNSchengen = TotalPmrTrans("N");
        }

        public List<Stand> StandList(int pier, bool remoto)
        {
            if (pier > 0)
            {
                List<Stand> myList = db.Stands.Where(
                    g => g.PierID.Equals(pier) && g.Remoto == remoto
                    ).ToList();

                return myList;
            }
            else
            {
                List<Stand> myList = db.Stands.Where(
                    g => g.Remoto == remoto
                    ).ToList();

                return myList;
            }
        }

        public List<Porta> GateList(bool schengen, bool terminal, bool t2)
        {
            if (t2 == true)
            {
                List<Porta> myList = db.Portas.Where(
                    g => g.Terminal == terminal
                    ).ToList();

                return myList;
            }
            else
            {
                List<Porta> myList = db.Portas.Where(
                    g => g.Schengen == schengen && g.Terminal == terminal
                    ).ToList();

                return myList;
            }

        }

        public int TotaisPmr(bool total, string mov)
        {
            if (total == true)
            {
                int PmrCount = db.AssistenciasPRMS.Where(
                    d => d.Data.Date == Hoje
                    ).Select(v => v.ID).Count();

                return PmrCount;
            }
            else
            {
                int PmrCount = db.AssistenciasPRMS.Where(
                    d => d.Data.Date == Hoje
                    && d.Mov == mov
                    ).Select(v => v.ID).Count();

                return PmrCount;
            }
        }

        public int TotalPmrDep(List<string> lista)
        {
            int PmrCount = db.AssistenciasPRMS.Where(
                d => d.Data.Date == Hoje
                && d.Mov == "D"
                && lista.Contains(d.Gate)
                ).Select(v => v.ID).Count();

            return PmrCount;
        }

        public int TotalPmrArr(bool Schengen)
        {
            if (Schengen)
            {
                int PmrCount = db.AssistenciasPRMS.Where(
                    d => d.Data.Date == Hoje
                    && d.Mov == "A"
                    && ExitSchengen.Contains(d.Exit)
                    ).Select(v => v.ID).Count();

                return PmrCount;
            }
            else
            {
                int PmrCount = db.AssistenciasPRMS.Where(
                    d => d.Data.Date == Hoje
                    && d.Mov == "A"
                    && d.Exit == "N"
                    ).Select(v => v.ID).Count();

                return PmrCount;
            }

        }

        public int TotalPmrTrans(string exit)
        {
            int PmrCount = db.AssistenciasPRMS.Where(
                d => d.Data.Date == Hoje
                && d.Mov == "A"
                && d.Exit == exit
                && d.Transferencia == "T"
                ).Select(v => v.ID).Count();

            return PmrCount;
        }

    }
}