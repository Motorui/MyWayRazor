﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models.Tabelas;

namespace MyWayRazor.Pages.Tabelas.Statuses
{
    public class DeleteModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public DeleteModel(MyWayRazor.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Status = await _context.Statuses.FindAsync(id);

            if (Status != null)
            {
                _context.Statuses.Remove(Status);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
