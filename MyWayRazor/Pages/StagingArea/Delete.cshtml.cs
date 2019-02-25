using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Staging;

namespace MyWayRazor.Pages.StagingArea
{
    public class DeleteModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public DeleteModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Staging Staging { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staging = await _context.Stagings
                .Include(s => s.Status).FirstOrDefaultAsync(m => m.ID == id);

            if (Staging == null)
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

            Staging = await _context.Stagings.FindAsync(id);

            if (Staging != null)
            {
                _context.Stagings.Remove(Staging);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
