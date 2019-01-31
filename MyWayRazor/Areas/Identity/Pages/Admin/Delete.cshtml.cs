using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Areas.Identity.Models;
using MyWayRazor.Data;

namespace MyWayRazor.Areas.Identity.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        [BindProperty]
        public ApplicationRole ApplicationRole { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser = await _userManager.Users.Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role).FirstOrDefaultAsync(m => m.Id == id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser = await _userManager.Users.Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role).FirstOrDefaultAsync(m => m.Id == id);

            ApplicationRole = await _context.ApplicationRole.FindAsync(id);

            if (ApplicationUser != null)
            {
                if (ApplicationRole != null)
                {
                    _context.ApplicationRole.Remove(ApplicationRole);
                }
                _context.Users.Remove(ApplicationUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
