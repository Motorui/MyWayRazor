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
    [Breadcrumb("Formações do Formando", FromPage = typeof(IndexModel))]
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
        public List<HistoricoFormacaoColaborador> HistoricoFormacoesColaborador { get; private set; }
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

            HistoricoFormacoesColaborador = await db.HistoricoFormacoesColaboradores
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

            return RedirectToPage("ColaboradorFormacao", new { id = colId }).WithSuccess("Well done!", "Formação adicionada com sucesso!");
        }

        private int Validade(Guid id)
        {
            return db.Formacoes.Where(i => i.FormacaoId == id).Select(v => v.FormacaoValidade).SingleOrDefault();
        }

        public async Task<IActionResult> OnGetEnviarHistoricoAsync(Guid? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            FormacaoColaborador fc = await db.FormacoesColaboradores.FindAsync(id);
            if (fc == null)
                return NotFound();

            int colId = fc.ColaboradorId;

            HistoricoFormacaoColaborador copyFc = new HistoricoFormacaoColaborador
            {
                HistoricoFormacaoColaboradorId = fc.FormacaoColaboradorId,
                FormacaoId = fc.FormacaoId,
                Formacao = fc.Formacao,
                ColaboradorId = fc.ColaboradorId,
                FormacaoData = fc.FormacaoData,
                FormacaoCaducidade = fc.FormacaoCaducidade
            };

            db.HistoricoFormacoesColaboradores.Add(copyFc);
            db.FormacoesColaboradores.RemoveRange(db.FormacoesColaboradores.Where(d => d.FormacaoColaboradorId == id));

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormacaoColaboradorExists(fc.FormacaoColaboradorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("ColaboradorFormacao", new { id = colId }).WithSuccess("Ok.", "Formação arquivada com sucesso!");
        }

        public async Task<IActionResult> OnGetReativarAsync(Guid? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HistoricoFormacaoColaborador hfc = await db.HistoricoFormacoesColaboradores.FindAsync(id);
            if (hfc == null)
                return NotFound();

            int colId = hfc.ColaboradorId;

            FormacaoColaborador copyFc = new FormacaoColaborador
            {
                FormacaoColaboradorId = hfc.HistoricoFormacaoColaboradorId,
                FormacaoId = hfc.FormacaoId,
                Formacao = hfc.Formacao,
                ColaboradorId = hfc.ColaboradorId,
                FormacaoData = hfc.FormacaoData,
                FormacaoCaducidade = hfc.FormacaoCaducidade
            };

            db.FormacoesColaboradores.Add(copyFc);
            db.HistoricoFormacoesColaboradores.RemoveRange(db.HistoricoFormacoesColaboradores.Where(d => d.HistoricoFormacaoColaboradorId == id));

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricoFormacaoColaboradorExists(hfc.HistoricoFormacaoColaboradorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("ColaboradorFormacao", new { id = colId }).WithSuccess("Ok.", "Formação reativada com sucesso!");
        }

        private bool FormacaoColaboradorExists(Guid id)
        {
            return db.FormacoesColaboradores.Any(e => e.FormacaoColaboradorId == id);
        }

        private bool HistoricoFormacaoColaboradorExists(Guid id)
        {
            return db.HistoricoFormacoesColaboradores.Any(e => e.HistoricoFormacaoColaboradorId == id);
        }

        public async Task<IActionResult> OnGetApagarFormacaoAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FormacaoColaborador fc = await db.FormacoesColaboradores.FindAsync(id);
            if (fc == null)
                return NotFound();

            int colId = fc.ColaboradorId;

            if (fc != null)
            {
                db.FormacoesColaboradores.Remove(fc);
                await db.SaveChangesAsync();
            }

            return RedirectToPage("ColaboradorFormacao", new { id = colId }).WithSuccess("Ok.", "Formação apagada com sucesso!");
        }

        public async Task<IActionResult> OnGetApagarHistoricoAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HistoricoFormacaoColaborador hfc = await db.HistoricoFormacoesColaboradores.FindAsync(id);
            if (hfc == null)
                return NotFound();

            int colId = hfc.ColaboradorId;

            if (hfc != null)
            {
                db.HistoricoFormacoesColaboradores.Remove(hfc);
                await db.SaveChangesAsync();
            }

            return RedirectToPage("ColaboradorFormacao", new { id = colId }).WithSuccess("Ok.", "Formação apagada com sucesso!");
        }

    }
}