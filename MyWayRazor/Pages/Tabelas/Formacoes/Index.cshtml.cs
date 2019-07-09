using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Formacoes;

namespace MyWayRazor.Pages.Tabelas.Formacoes
{
    public class IndexModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public IndexModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Formacao> Formacao { get;set; }

        public async Task OnGetAsync()
        {
            Formacao = await _context.Formacoes.ToListAsync();
        }
    }
}
