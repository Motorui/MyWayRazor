using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;
using SmartBreadcrumbs.Attributes;

namespace MyWayRazor.Pages.Analise
{
    [Breadcrumb("Análise")]
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext context)
        {
            db = context;
        }

        public DateTime Hoje = DateTime.UtcNow.Date;
        public IList<AssistenciasPRM> AssistenciasPRMs { get; set; }

        public async Task OnGetAsync()
        {
            AssistenciasPRMs = await db.AssistenciasPRMS.Where(d => d.Data.Date == Hoje && d.OrigDest != "").ToListAsync();
        }
    }
}