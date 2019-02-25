using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;

namespace MyWayRazor.Pages.tempFolder
{
    public class EditModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public EditModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssistenciasPRM AssistenciasPRM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AssistenciasPRM = await _context.AssistenciasPRMS.FirstOrDefaultAsync(m => m.ID == id);

            if (AssistenciasPRM == null)
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

            _context.Attach(AssistenciasPRM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssistenciasPRMExists(AssistenciasPRM.ID))
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

        private bool AssistenciasPRMExists(int id)
        {
            return _context.AssistenciasPRMS.Any(e => e.ID == id);
        }
    }
}
