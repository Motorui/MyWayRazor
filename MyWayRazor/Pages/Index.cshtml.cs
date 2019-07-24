using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Extensions.Alerts;
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
            ToDoList = await db.ToDos.Where(t => t.Done == false).ToListAsync();
            AssistenciasHoje = await db.AssistenciasPRMS.Where(d => d.Data.Date == Hoje && d.OrigDest != "").ToListAsync();
            AssistenciasAmanha = await db.AssistenciasPRMS.Where(d => d.Data.Date == Amanha && d.OrigDest != "").ToListAsync();
            FtesHoje = await db.Escalas.Where(d => d.Dia.Date == Hoje).ToListAsync();
            FtesAmanha = await db.Escalas.Where(d => d.Dia.Date == Amanha).ToListAsync();
            ListaCaducidades = await db.FormacoesColaboradores
                .Include(f => f.Formacao)
                .Include(c => c.Colaborador).Where(c=> c.Colaborador.Ativo == true)
                .Where(d => d.FormacaoCaducidade <= DataTresMeses).ToListAsync();
        }

        public async Task<IActionResult> OnGetMarkDoneAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ToDo todo = db.ToDos.FirstOrDefault(i => i.ToDoId == id);
            if (todo == null)
                return NotFound();

            todo.Done = true;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(todo.ToDoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index").WithSuccess("Well done!", "Item desativado com sucesso!");
        }

        private bool TodoExists(int id)
        {
            return db.ToDos.Any(e => e.ToDoId == id);
        }

    }
}
