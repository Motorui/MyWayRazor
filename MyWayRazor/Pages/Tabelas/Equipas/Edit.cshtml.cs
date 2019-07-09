using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models.Tabelas;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Tabelas.Equipas
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public EditModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Equipa Equipa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipa = await _context.Equipas.FirstOrDefaultAsync(m => m.EquipaId == id);

            if (Equipa == null)
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

            Equipa.EquipaNome = Request.Form["Equipa.EquipaNome"].ToString().ToUpper();
            Equipa.LastUpdatedAt = DateTime.UtcNow.Date;
            Equipa.LastUpdatedBy = User.Identity.Name.ToString();
            _context.Attach(Equipa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipaExists(Equipa.EquipaId))
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

        private bool EquipaExists(int id)
        {
            return _context.Equipas.Any(e => e.EquipaId == id);
        }
    }
}
