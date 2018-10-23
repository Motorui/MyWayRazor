using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Equipas
{
    public class DeleteModel : PageModel
    {
        private readonly MyWayRazor.Data.MywayDbContext _context;

        public DeleteModel(MyWayRazor.Data.MywayDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipa = await _context.Equipas.FindAsync(id);

            if (Equipa != null)
            {
                _context.Equipas.Remove(Equipa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
