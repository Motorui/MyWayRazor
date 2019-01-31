using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWayRazor.Areas.Identity.Models;
using MyWayRazor.Data;

namespace MyWayRazor.Areas.Identity.Pages.Admin.Roles
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ApplicationRole ApplicationRole { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ApplicationRole.Add(ApplicationRole);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}