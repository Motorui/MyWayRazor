using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;
using MyWayRazor.Models.Formacoes;
using MyWayRazor.Models.ToDoList;
using SmartBreadcrumbs.Attributes;

namespace MyWayRazor.Pages
{

    [DefaultBreadcrumb("Início")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public bool IsChecked { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            db = context;
        }

        public DateTime Hoje = DateTime.UtcNow.Date;
        public DateTime Amanha = DateTime.UtcNow.Date.AddDays(1);
        public DateTime DataTresMeses = DateTime.UtcNow.Date.AddMonths(3);
        public IList<AssistenciasPRM> AssistenciasHoje { get; set; }
        public IList<AssistenciasPRM> AssistenciasAmanha { get; set; }
        public IList<Escala> FtesHoje { get; set; }
        public IList<Escala> FtesAmanha { get; set; }
        public IList<FormacaoColaborador> ListaCaducidades { get; set; }

        [BindProperty]
        public ToDo ToDo { get; set; }
        public IList<ToDo> ToDoList { get; set; }
        public async Task OnGetAsync()
        {
            ToDoList = await db.ToDos.ToListAsync();
            AssistenciasHoje = await db.AssistenciasPRMS.Where(d => d.Data.Date == Hoje && d.OrigDest != "").ToListAsync();
            AssistenciasAmanha = await db.AssistenciasPRMS.Where(d => d.Data.Date == Amanha && d.OrigDest != "").ToListAsync();
            FtesHoje = await db.Escalas.Where(d => d.Dia.Date == Hoje).ToListAsync();
            FtesAmanha = await db.Escalas.Where(d => d.Dia.Date == Amanha).ToListAsync();
            ListaCaducidades = await db.FormacoesColaboradores
                .Include(f => f.Formacao)
                .Include(c => c.Colaborador)
                .Where(d => d.FormacaoCaducidade <= DataTresMeses).ToListAsync();
        }

        public async Task<IActionResult> OnPostMarkDone(int id)
        {
            if (id == 0)
            {
                return Page();
            }

            var successful = await MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }

            return RedirectToPage("./Index");
        }

        public async Task<bool> MarkDoneAsync(int id)
        {
            var item = await db.ToDos
                .Where(x => x.ToDoId == id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            item.Done = true;

            var saveResult = await db.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }

        private bool ToDoExists(int id)
        {
            return db.ToDos.Any(e => e.ToDoId == id);
        }
    }
}
