using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;
using MyWayRazor.Models.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Analise
{
    public class PmrTerminalModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public PmrTerminalModel(ApplicationDbContext context)
        {
            db = context;
        }

        public DateTime Hoje = DateTime.UtcNow.Date;
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
        public int TotalPMR { get; private set; }
        public int TotalPMRDep { get; private set; }
        public int TotalPMRArr { get; private set; }
        public int TotalAPierSul { get; private set; }
        public int TotalAPierNorte { get; private set; }
        public int TotalAPier14 { get; private set; }
        public int TotalARemoto { get; private set; }
        public int TotalDepS { get; private set; }
        public int TotalDepN { get; private set; }
        public int TotalDepT2 { get; private set; }

        public async Task OnGetAsync()
        {
            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Análise",
                Url = "/Analise",
                Order = 1
            });
            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "PMR Terminal",
                Url = "/Analise/PmrTerminal",
                Order = 2
            });

            AssistenciasPRMs = await db.AssistenciasPRMS.ToListAsync();
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

            TotalPMR = TotaisPmr(true, "");
            TotalPMRDep = TotaisPmr(false, "D");
            TotalPMRArr = TotaisPmr(false, "A");

            TotalAPierSul = TotalArr(PierSul);
            TotalAPierNorte = TotalArr(PierNorte);
            TotalAPier14 = TotalArr(Pier14);
            TotalARemoto = TotalArr(Remotos);

            TotalDepS = TotalDep(GateSchengen);
            TotalDepN = TotalDep(GateNSchengen);
            TotalDepT2 = TotalDep(GateT2);

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

        public int TotalDep(List<string> lista)
        {
                int PmrCount = db.AssistenciasPRMS.Where(
                    d => d.Data.Date == Hoje
                    && d.Mov == "D"
                    && lista.Contains(d.Gate)
                    ).Select(v => v.ID).Count();

                return PmrCount;
        }

        public int TotalArr(List<int> lista)
        {
            int PmrCount = db.AssistenciasPRMS.Where(
                d => d.Data.Date == Hoje
                && d.Mov == "A"
                && lista.Contains(int.Parse(d.Stand))
                ).Select(v => v.ID).Count();

            return PmrCount;
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

    }
}
