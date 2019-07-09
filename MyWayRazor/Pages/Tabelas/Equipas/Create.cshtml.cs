using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWayRazor.Models.Tabelas;
using System;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Tabelas.Equipas
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
        public Equipa Equipa { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Equipa.EquipaNome = Request.Form["Equipa.EquipaNome"].ToString().ToUpper();
            Equipa.CreatedAt = DateTime.UtcNow.Date;
            Equipa.CreatedBy = User.Identity.Name.ToString();
            _context.Equipas.Add(Equipa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}