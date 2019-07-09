using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models.Tabelas;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Tabelas.Horarios
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public EditModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Horario Horario { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Horario = await _context.Horarios.FirstOrDefaultAsync(m => m.HorarioId == id);

            if (Horario == null)
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

            Horario.LastUpdatedAt = DateTime.UtcNow.Date;
            Horario.LastUpdatedBy = User.Identity.Name.ToString();
            _context.Attach(Horario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioExists(Horario.HorarioId))
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

        private bool HorarioExists(int id)
        {
            return _context.Horarios.Any(e => e.HorarioId == id);
        }
    }
}
