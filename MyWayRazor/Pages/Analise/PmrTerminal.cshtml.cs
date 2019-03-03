using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;
using MyWayRazor.Models.Tabelas;
using System.Collections.Generic;
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

        public IList<AssistenciasPRM> AssistenciasPRMs { get; set; }
        public IList<Porta> Portas { get; set; }
        public IList<Stand> Stands { get; set; }
        public IList<Parametro> Parametros { get; set; }

        public async Task OnGetAsync()
        {
            AssistenciasPRMs = await db.AssistenciasPRMS.ToListAsync();
            Portas = await db.Portas.ToListAsync();
            Stands = await db.Stands.ToListAsync();
            Parametros = await db.Parametros.ToListAsync();
        }
    }
}
