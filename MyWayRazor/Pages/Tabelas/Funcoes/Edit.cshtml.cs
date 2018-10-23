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

namespace MyWayRazor.Pages.Tabelas.Funcoes
{
    public class EditModel : PageModel
    {
        private readonly MyWayRazor.Data.MywayDbContext _context;

        public EditModel(MyWayRazor.Data.MywayDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Funcao Funcao { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Funcao = await _context.Funcoes.FirstOrDefaultAsync(m => m.FuncaoId == id);

            if (Funcao == null)
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


            Funcao.FuncaoNome = Request.Form["Funcao.FuncaoNome"].ToString().ToUpper();
            Funcao.LastUpdatedAt = DateTime.Now.Date;
            Funcao.LastUpdatedBy = User.Identity.Name.ToString();
            _context.Attach(Funcao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncaoExists(Funcao.FuncaoId))
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

        private bool FuncaoExists(int id)
        {
            return _context.Funcoes.Any(e => e.FuncaoId == id);
        }
    }
}
