using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Formacoes;

namespace MyWayRazor.Pages.Tabelas.Formacoes
{
    public class EditModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public EditModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Formacao Formacao { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Formacao = await _context.Formacoes.FirstOrDefaultAsync(m => m.FormacaoId == id);

            if (Formacao == null)
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

            //string emailAddress = String.ToUpper(Request.Form["Formacao.FormacaoNome"].ToString());

            _context.Attach(Formacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormacaoExists(Formacao.FormacaoId))
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

        private bool FormacaoExists(Guid id)
        {
            return _context.Formacoes.Any(e => e.FormacaoId == id);
        }
    }
}
