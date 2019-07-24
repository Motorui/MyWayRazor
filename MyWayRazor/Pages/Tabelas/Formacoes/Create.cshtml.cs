using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Formacoes;

namespace MyWayRazor.Pages.Tabelas.Formacoes
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public CreateModel(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Formacao Formacao { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Formacoes.Add(Formacao);
            await db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}