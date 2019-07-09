using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models.Tabelas;

namespace MyWayRazor.Pages.Tabelas.Uhs
{
    public class IndexModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public IndexModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Uh> Uh { get;set; }

        public async Task OnGetAsync()
        {
            Uh = await _context.Uhs.ToListAsync();
        }
    }
}
