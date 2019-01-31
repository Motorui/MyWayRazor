using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Departamentos
{
    public class DeleteModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public DeleteModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Departamento Departamento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departamento = await _context.Departamentos.FirstOrDefaultAsync(m => m.DepartamentoId == id);

            if (Departamento == null)
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

            Departamento = await _context.Departamentos.FindAsync(id);

            if (Departamento != null)
            {
                _context.Departamentos.Remove(Departamento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
