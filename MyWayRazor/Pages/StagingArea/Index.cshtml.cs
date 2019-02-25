using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;
using MyWayRazor.Models.Staging;
using MyWayRazor.Models.Tabelas;

namespace MyWayRazor.Pages.StagingArea
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private int bt;
        public string Message { get; set; } = "Initial Request";

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AssistenciasPRM> AssistenciasPRM { get; set; }
        public IList<Porta> Porta { get; set; }

        public async Task OnGetAsync()
        {
            AssistenciasPRM = await _context.AssistenciasPRMS.ToListAsync();
            Porta = await _context.Portas.ToListAsync();
        }

        [BindProperty]
        public Staging Staging { get; set; }
        public async Task<IActionResult> CreateAsync(int id)
        {
            var AssistenciasPRMQuery = _context.AssistenciasPRMS.First(a => a.ID == id);
            var PortaQuery = _context.Portas.First(p => p.PortaNum == AssistenciasPRMQuery.Gate);

            if (PortaQuery.Schengen)
            {
                bt = 40;
            }
            else
            {
                bt = 60;
            }

            int tp = PortaQuery.PortaTempo;
            int tempo = tp + bt;

            Staging Data = new Staging
            {
                Msg = AssistenciasPRMQuery.Msg,
                Notif = AssistenciasPRMQuery.Notif,
                Data = AssistenciasPRMQuery.Data,
                Voo = AssistenciasPRMQuery.Voo,
                Mov = AssistenciasPRMQuery.Mov,
                OrigemDestino = AssistenciasPRMQuery.OrigDest,
                Pax = AssistenciasPRMQuery.Pax,
                Ssr = AssistenciasPRMQuery.SSR,
                AirCraft = AssistenciasPRMQuery.AC,
                Stand = AssistenciasPRMQuery.Stand,
                CheckIn = AssistenciasPRMQuery.CkIn,
                Gate = AssistenciasPRMQuery.Gate,
                Remark = null,
                Etd = AssistenciasPRMQuery.Data,
                Antecipar = AssistenciasPRMQuery.Data.AddMinutes(-40),
                Horario = AssistenciasPRMQuery.Data.AddMinutes(-60),
                StatusId = 1,
                Destino = true,
                Alerta = true,
                Observacao = null
            };


            _context.Stagings.Add(Data);
            await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");

            Message = tempo.ToString();
            return Page();
        }
    }
}
