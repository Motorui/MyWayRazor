using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Staging;

namespace MyWayRazor.Pages.StagingArea
{
    public class EditModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public EditModel(MyWayRazor.Data.ApplicationDbContext context)
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
           ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusID", "Statuses");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Staging).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StagingExists(Staging.ID))
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

        private bool StagingExists(int id)
        {
            return _context.Stagings.Any(e => e.ID == id);
        }
    }
}
