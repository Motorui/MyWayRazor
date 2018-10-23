using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Horarios
{
    public class CreateModel : PageModel
    {
        private readonly MyWayRazor.Data.MywayDbContext _context;

        public CreateModel(MyWayRazor.Data.MywayDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Horario Horario { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Horario.CreatedAt = DateTime.Now.Date;
            Horario.CreatedBy = User.Identity.Name.ToString();
            _context.Horarios.Add(Horario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}