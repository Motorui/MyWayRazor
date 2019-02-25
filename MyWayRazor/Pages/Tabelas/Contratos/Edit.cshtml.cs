using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Contratos
{
    public class EditModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public EditModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contrato Contrato { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contrato = await _context.Contratos.FirstOrDefaultAsync(m => m.ContratoId == id);

            if (Contrato == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Contrato.ContratoTipo = Request.Form["Contrato.ContratoTipo"].ToString().ToUpper();
            Contrato.LastUpdatedAt = DateTime.UtcNow.Date;
            Contrato.LastUpdatedBy = User.Identity.Name.ToString();
            _context.Attach(Contrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(Contrato.ContratoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContratoExists(int id)
        {
            return _context.Contratos.Any(e => e.ContratoId == id);
        }
    }
}
