using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Uhs
{
    public class EditModel : PageModel
    {
        private readonly MyWayRazor.Data.MywayDbContext _context;

        public EditModel(MyWayRazor.Data.MywayDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Uh Uh { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Uh = await _context.Uhs.FirstOrDefaultAsync(m => m.UhId == id);

            if (Uh == null)
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

            _context.Attach(Uh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UhExists(Uh.UhId))
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

        private bool UhExists(int id)
        {
            return _context.Uhs.Any(e => e.UhId == id);
        }
    }
}
