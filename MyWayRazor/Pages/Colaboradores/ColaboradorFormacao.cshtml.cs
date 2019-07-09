using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Extensions.Alerts;
using MyWayRazor.Models.Colaboradores;
using MyWayRazor.Models.Formacoes;
using SmartBreadcrumbs.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Colaboradores
{
    [Breadcrumb("Formações Colaborador", FromPage = typeof(IndexModel))]
    public class ColaboradorFormacaoModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public ColaboradorFormacaoModel(ApplicationDbContext context)
        {
            db = context;
        }

        public Formacao Formacao { get; }

        [BindProperty]
        public Colaborador Colaborador { get; set; }
        public List<FormacaoColaborador> FormacoesColaborador { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Colaborador = await db.Colaboradores.FirstOrDefaultAsync(m => m.ColaboradorID == id);

            if (Colaborador == null)
            {
                return NotFound();
            }

            ViewData["ColaboradorId"] = new SelectList(db.Colaboradores, "ColaboradorID", "Nome");
            ViewData["FormacaoId"] = new SelectList(db.Formacoes, "FormacaoId", "FormacaoNome");

            FormacoesColaborador = await db.FormacoesColaboradores
                .Include(c => c.Formacao)
                .Where(d => d.ColaboradorId == id).ToListAsync();

            return Page();
        }

        [BindProperty]
        public FormacaoColaborador FormacaoColaborador { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Debug.AutoFlush = true;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Guid formacaoId = Guid.Parse(Request.Form["FormacaoColaborador.FormacaoId"]);
            int colId = int.Parse(Request.Form["Colaborador.ColaboradorID"]);
            DateTime formacaoData = DateTime.Parse(Request.Form["FormacaoColaborador.FormacaoData"]);
            int validade = Validade(formacaoId);
            DateTime caducidade = formacaoData.AddYears(validade);

            DateTime now = DateTime.UtcNow;
            string user = User.Identity.Name;

            FormacaoColaborador novaFormacao = new FormacaoColaborador
            {
                FormacaoId = formacaoId,
                ColaboradorId = colId,
                FormacaoData = formacaoData,
                FormacaoCaducidade = caducidade,
                CreatedAt = now,
                CreatedBy = user
            };

            db.FormacoesColaboradores.Add(novaFormacao);
            await db.SaveChangesAsync();

            //Trace.WriteLine(novaFormacao);
            //return RedirectToPage("Index").WithSuccess("Well done!", "Formação adicionada com sucesso!");
            //return Page();
            return RedirectToPage("ColaboradorFormacao", new { id = colId }).WithSuccess("Well done!", "Formação adicionada com sucesso!");
        }

        private bool ColaboradorExists(int id)
        {
            return db.Colaboradores.Any(e => e.ColaboradorID == id);
        }

        private int Validade(Guid id)
        {
            return db.Formacoes.Where(i => i.FormacaoId == id).Select(v => v.FormacaoValidade).SingleOrDefault();
        }

    }
}