using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Contratos
{
    public class IndexModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public IndexModel(MyWayRazor.Data.ApplicationDbContext context)
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
