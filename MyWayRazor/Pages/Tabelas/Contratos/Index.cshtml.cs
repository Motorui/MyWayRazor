using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models.Tabelas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Tabelas.Contratos
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Contrato> Contrato { get;set; }

        public async Task OnGetAsync()
        {
            Contrato = await _context.Contratos.ToListAsync();
        }
    }
}
