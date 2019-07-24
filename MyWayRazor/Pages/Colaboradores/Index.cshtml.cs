using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Extensions.Alerts;
using MyWayRazor.Models.Colaboradores;
using SmartBreadcrumbs.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Colaboradores
{
    [Breadcrumb("Formandos")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext context)
        {
            db = context;
        }

        public IList<Colaborador> ColaboradorLista { get;set; }

        public async Task OnGetAsync()
        {
            ColaboradorLista = await db.Colaboradores
                .Include(c => c.Categoria)
                .Include(c => c.Contrato)
                .Include(c => c.Departamento)
                .Include(c => c.Equipa)
                .Include(c => c.Funcao)
                .Include(c => c.HorarioContratado)
                .Include(c => c.HorarioPraticado)
                .Include(c => c.Uh)
                .Where(c => c.Ativo == true)
                .ToListAsync();
        }

        [BindProperty]
        public Colaborador Colaborador { get; set; }
        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Colaborador = await db.Colaboradores.FindAsync(id);

            if (Colaborador != null)
            {
                db.Colaboradores.Remove(Colaborador);
                await db.SaveChangesAsync();
            }

            return RedirectToPage("Index").WithSuccess("Well done!", "Formando apagado com sucesso!");
        }

        public async Task<IActionResult> OnGetDesativarAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //db.Attach(Colaborador).State = EntityState.Modified;
            Colaborador colaborador = db.Colaboradores.FirstOrDefault(i => i.ColaboradorID == id);
            if (colaborador == null)
                return NotFound();

            colaborador.Ativo = false;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboradorExists(Colaborador.ColaboradorID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index").WithSuccess("Well done!", "Formando desativado com sucesso!");
        }

        private bool ColaboradorExists(int id)
        {
            return db.Colaboradores.Any(e => e.ColaboradorID == id);
        }

    }
}
