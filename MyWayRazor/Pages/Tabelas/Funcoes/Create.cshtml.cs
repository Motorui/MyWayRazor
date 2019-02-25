using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Funcoes
{
    public class CreateModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public CreateModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Funcao Funcao { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Funcao.FuncaoNome = Request.Form["Funcao.FuncaoNome"].ToString().ToUpper();
            Funcao.LastUpdatedAt = DateTime.UtcNow.Date;
            Funcao.LastUpdatedBy = User.Identity.Name.ToString();
            _context.Funcoes.Add(Funcao);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}