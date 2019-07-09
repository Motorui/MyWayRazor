using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWayRazor.Models.Tabelas;
using System;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Tabelas.Funcoes
{
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public CreateModel(Data.ApplicationDbContext context)
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