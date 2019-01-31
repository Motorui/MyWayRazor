using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Areas.Identity.Models;
using MyWayRazor.Data;

namespace MyWayRazor.Areas.Identity.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public const string StatusMessage = nameof(StatusMessage);

        public IndexModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public IEnumerable<ApplicationUser> UserData { get; set; }

        public void OnGetAsync()
        {
            UserData = userManager.Users.Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ToList();
        }


    }
}
