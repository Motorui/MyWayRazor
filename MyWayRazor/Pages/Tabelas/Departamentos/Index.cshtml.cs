using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models.Tabelas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Tabelas.Departamentos
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Departamento> Departamento { get;set; }

        public async Task OnGetAsync()
        {
            Departamento = await _context.Departamentos.ToListAsync();
        }
    }
}
