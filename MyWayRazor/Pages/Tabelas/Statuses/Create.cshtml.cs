using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Statuses
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
        public Status Status { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Status.Statuses = Request.Form["Status.Statuses"].ToString().ToUpper();
            Status.CreatedAt = DateTime.Now.Date;
            Status.CreatedBy = User.Identity.Name.ToString();
            _context.Statuses.Add(Status);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}