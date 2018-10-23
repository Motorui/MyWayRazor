using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Horarios
{
    public class IndexModel : PageModel
    {
        private readonly MyWayRazor.Data.MywayDbContext _context;

        public IndexModel(MyWayRazor.Data.MywayDbContext context)
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
