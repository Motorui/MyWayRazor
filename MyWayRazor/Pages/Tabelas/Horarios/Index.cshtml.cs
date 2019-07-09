using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models.Tabelas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Tabelas.Horarios
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Horario> Horario { get;set; }

        public async Task OnGetAsync()
        {
            Horario = await _context.Horarios.ToListAsync();
        }
    }
}
