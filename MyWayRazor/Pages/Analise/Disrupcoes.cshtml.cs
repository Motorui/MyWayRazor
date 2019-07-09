using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;
using SmartBreadcrumbs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Analise
{
    [Breadcrumb("Disrupções", FromPage = typeof(IndexModel))]
    public class DisrupcoesModel : PageModel
    {
        private readonly ApplicationDbContext db;
        private DateTime Dia { get; set; }

        public DisrupcoesModel(ApplicationDbContext context)
        {
            db = context;
        }

        public IList<DadosAeroporto> ListDadosAeroportos { get; set; }
        public IList<HistoricoAssistencia> ListHistoricoAssistencias { get; set; }
        public async Task OnGetAsync()
        {
            //Dia = DateTime.UtcNow;
            Dia = DateTime.Parse("01-06-2019");
            ListDadosAeroportos = await db.DadosAeroportos.Where(
                d => (d.ActualTimeUTC <= d.ScheduleTimeUTC.Value.AddMinutes(-30) || d.ActualTimeUTC >= d.ScheduleTimeUTC.Value.AddMinutes(30))
                && d.ScheduleTimeUTC.Value.Day >= Dia.Day && d.ScheduleTimeUTC.Value.Day <= Dia.Day
                ).ToListAsync();
            ListHistoricoAssistencias = await db.HistoricoAssistencias.Where(d => d.Data.Day >= Dia.Day && d.Data.Day <= Dia.Day).ToListAsync();
         }
    }
}