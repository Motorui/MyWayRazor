using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;

namespace MyWayRazor.Pages.Analise
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;
        private readonly DbSet<AssistenciasPRM> dt;

        public IndexModel(ApplicationDbContext context)
        {
            db = context;
            dt = db.AssistenciasPRMS;
        }

        #region Plataformas
        readonly IList<string> Plataforma10 = new List<string>(new[] {
            "104", "105", "106", "107", "108"
        });
        readonly IList<string> Plataforma11 = new List<string>(new[] {
            "114", "115", "116", "117"
        });
        readonly IList<string> Plataforma12 = new List<string>(new[] {
            "122", "123", "124", "125", "126"
        });
        readonly IList<string> Plataforma14 = new List<string>(new[] {
            "141", "142", "143", "144", "145", "146", "147"
        }); 
        readonly IList<string> Plataforma20 = new List<string>(new[] {
            "200", "201", "202", "203", "204", "205", "206", "207", "208", "209"
        });
        readonly IList<string> Plataforma22 = new List<string>(new[] {
            "221", "222", "223", "224", "225"
        });
        readonly IList<string> Plataforma30 = new List<string>(new[] {
            "301", "302"
        });
        readonly IList<string> Plataforma40 = new List<string>(new[] {
            "401", "402", "403", "404", "405"
        });
        readonly IList<string> Plataforma41 = new List<string>(new[] {
            "411", "412", "413", "414", "415", "416"
        });
        readonly IList<string> Plataforma42 = new List<string>(new[] {
            "421", "422", "423", "424", "425", "426"
        });
        readonly IList<string> Plataforma50 = new List<string>(new[] {
            "501", "502", "503", "504", "505", "506"
        });
        readonly IList<string> Plataforma60 = new List<string>(new[] {
            "601", "602", "603", "604", "605", "606", "607", "608", "609"
        });
        readonly IList<string> Plataforma70 = new List<string>(new[] {
            "701", "702", "703", "704", "705", "706"
        });
        readonly IList<string> Plataforma80 = new List<string>(new[] {
            "801", "802", "803", "804", "805", "806"
        });
        #endregion

        #region Portas

        readonly IList<string> PortasT1SM = new List<string>(new[] {
            "7", "14", "15", "16", "17", "22", "23", "25"
        });
        readonly IList<string> PortasT1NR = new List<string>(new[] {
            "41A", "42A", "43A", "43B", "44A", "44B", "45A",
            "45B", "46A", "47A"
        });
        readonly IList<string> PortasT1NM = new List<string>(new[] {
            "26", "27", "41", "42", "43", "44", "45",
            "46", "47"
        });
        readonly IList<string> PortasT2 = new List<string>(new[] {
            "201", "202", "203", "204", "205", "206", "207", "208",
            "209", "209A", "210", "211", "212", "212A", "214"
        });
        #endregion

        public IList<AssistenciasPRM> AssistenciasPRMA { get; set; }
        public IList<AssistenciasPRM> AssistenciasPRMD { get; set; }
        public IList<AssistenciasPRM> AssistenciasPRMATotal { get; set; }
        public IList<AssistenciasPRM> AssistenciasPRMDTotal { get; set; }
        public string NumChegadas { get; private set; }
        public string NumPartidas { get; private set; }

        public string Agora { get; private set; }
        public string AgoraMaisUmaHora { get; private set; }

        public async Task OnGetAsync()
        {
            DateTime currentTime = DateTime.Now;
            DateTime OneHourLater = currentTime.AddHours(1);

            var Plataformas10a14 = Plataforma10.Concat(Plataforma11).Concat(Plataforma12).Concat(Plataforma14);
            var Plataformas30a40 = Plataforma30.Concat(Plataforma40);
            var Plataformas41a60 = Plataforma41.Concat(Plataforma42).Concat(Plataforma50).Concat(Plataforma60);
            var Plataformas70a80 = Plataforma70.Concat(Plataforma80);

            var tblChegadas = dt
                .Where(
                    t => t.Data >= currentTime 
                    && t.Data <= OneHourLater 
                    && t.Mov == "A"
                    //&& t.Exit == "N"
                );

            var tblPartidas = dt
                .Where(
                    t => t.Data >= currentTime 
                    && t.Data <= OneHourLater 
                    && t.Mov == "D"
                    //&& Plataformas10a14.Contains(t.Stand)
                );

            var tblChegadasTotal = dt
                .Where(
                    t => t.Data >= currentTime
                    && t.Mov == "A"
                );

            var tblPartidasTotal = dt
                .Where(
                    t => t.Data >= currentTime
                    && t.Mov == "D"
                );

            int NChegadas = dt
                .Where(t => t.Data >= currentTime && t.Data <= OneHourLater && t.Mov == "A")
                .Count(p => p.Aeroporto.Length > 0);

            int NPartidas = dt
                .Where(t => t.Data >= currentTime && t.Data <= OneHourLater && t.Mov == "D")
                .Count(p => p.Aeroporto.Length > 0);

            int numeroWCHRA = dt
                .Where(t => t.Data >= currentTime && t.Data <= OneHourLater && t.Mov == "D")
                .Count(p => p.SSR == "WCHR");

            AssistenciasPRMA = await tblChegadas.AsNoTracking().ToListAsync();
            AssistenciasPRMD = await tblPartidas.AsNoTracking().ToListAsync();
            AssistenciasPRMATotal = await tblChegadasTotal.AsNoTracking().ToListAsync();
            AssistenciasPRMDTotal = await tblPartidasTotal.AsNoTracking().ToListAsync();

            NumChegadas = NChegadas.ToString();
            NumPartidas = NPartidas.ToString();
            Agora = currentTime.ToShortTimeString();
            AgoraMaisUmaHora = OneHourLater.ToShortTimeString();

        }
    }
}