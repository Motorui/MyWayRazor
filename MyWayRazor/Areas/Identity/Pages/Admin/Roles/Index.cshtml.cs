using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Areas.Identity.Models;
using MyWayRazor.Data;

namespace MyWayRazor.Areas.Identity.Pages.Admin.Roles
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ApplicationRole> ApplicationRole { get;set; }

        public async Task OnGetAsync()
        {
            ApplicationRole = await _context.ApplicationRole.ToListAsync();
        }
    }
}
