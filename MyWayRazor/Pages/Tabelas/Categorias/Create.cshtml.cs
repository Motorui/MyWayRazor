using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Categorias
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
        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Categoria.CategoriaNome = Request.Form["Categoria.CategoriaNome"].ToString().ToUpper();
            Categoria.CreatedAt = DateTime.Now.Date;
            Categoria.CreatedBy = User.Identity.Name.ToString();
            _context.Categorias.Add(Categoria);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}