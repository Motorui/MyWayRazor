using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Colaboradores
{
    public class DeleteModel : PageModel
    {
        private readonly MyWayRazor.Data.MywayDbContext _context;

        public DeleteModel(MyWayRazor.Data.MywayDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Colaborador Colaborador { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Colaborador = await _context.Colaboradores
                .Include(c => c.Categoria)
                .Include(c => c.Contrato)
                .Include(c => c.Departamento)
                .Include(c => c.Equipa)
                .Include(c => c.Funcao)
                .Include(c => c.HorarioContratado)
                .Include(c => c.HorarioPraticado)
                .Include(c => c.Status)
                .Include(c => c.Uh).FirstOrDefaultAsync(m => m.ColaboradorID == id);

            if (Colaborador == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Colaborador = await _context.Colaboradores.FindAsync(id);

            if (Colaborador != null)
            {
                _context.Colaboradores.Remove(Colaborador);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
