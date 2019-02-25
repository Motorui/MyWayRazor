using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;

namespace MyWayRazor.Pages.tempFolder
{
    public class IndexModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public IndexModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AssistenciasPRM> AssistenciasPRM { get; set; }

        public async Task OnGetAsync()
        {
            AssistenciasPRM = await _context.AssistenciasPRMS.ToListAsync();
        }
    }
}
