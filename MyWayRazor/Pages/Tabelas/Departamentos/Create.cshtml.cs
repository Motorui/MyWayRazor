using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Departamentos
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
        public Departamento Departamento { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Departamento.DepartamentoNumero =  new int(Request.Form["Departamento.DepartamentoNumero"].ToString);
            Departamento.DepartamentoNome = Request.Form["Departamento.DepartamentoNome"].ToString().ToUpper();
            Departamento.CreatedAt = DateTime.Now.Date;
            Departamento.CreatedBy = User.Identity.Name.ToString();
            _context.Departamentos.Add(Departamento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}