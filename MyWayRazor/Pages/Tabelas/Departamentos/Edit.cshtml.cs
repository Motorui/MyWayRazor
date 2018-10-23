using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Departamentos
{
    public class EditModel : PageModel
    {
        private readonly MyWayRazor.Data.MywayDbContext _context;

        public EditModel(MyWayRazor.Data.MywayDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Departamento.DepartamentoNome = Request.Form["Departamento.DepartamentoNome"].ToString().ToUpper();
            Departamento.LastUpdatedAt = DateTime.Now.Date;
            Departamento.LastUpdatedBy = User.Identity.Name.ToString();
            _context.Attach(Departamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(Departamento.DepartamentoId))
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

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.DepartamentoId == id);
        }
    }
}
