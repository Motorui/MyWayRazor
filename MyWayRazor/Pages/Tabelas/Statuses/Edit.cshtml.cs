using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models.Tabelas;

namespace MyWayRazor.Pages.Tabelas.Statuses
{
    public class EditModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public EditModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Status Status { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Status = await _context.Statuses.FirstOrDefaultAsync(m => m.StatusID == id);

            if (Status == null)
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

            Status.Statuses = Request.Form["Status.Statuses"].ToString().ToUpper();
            Status.LastUpdatedAt = DateTime.UtcNow.Date;
            Status.LastUpdatedBy = User.Identity.Name.ToString();
            _context.Attach(Status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(Status.StatusID))
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

        private bool StatusExists(int id)
        {
            return _context.Statuses.Any(e => e.StatusID == id);
        }
    }
}
