using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Uhs
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
        public Uh Uh { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Uh.IATA = Request.Form["Uh.IATA"].ToString().ToUpper();
            Uh.UhNome = Request.Form["Uh.UhNome"].ToString().ToUpper();
            Uh.CreatedAt = DateTime.UtcNow.Date;
            Uh.CreatedBy = User.Identity.Name.ToString();
            _context.Uhs.Add(Uh);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}