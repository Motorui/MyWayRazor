using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models.Tabelas;

namespace MyWayRazor.Pages.Tabelas.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public IndexModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Categoria> Categoria { get;set; }

        public async Task OnGetAsync()
        {
            Categoria = await _context.Categorias.ToListAsync();
        }
    }
}
