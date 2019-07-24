using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Formacoes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Tabelas.Formacoes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext context)
        {
            db = context;
        }

        public IList<Formacao> Formacao { get;set; }

        public async Task OnGetAsync()
        {
            Formacao = await db.Formacoes.ToListAsync();
        }
    }
}
