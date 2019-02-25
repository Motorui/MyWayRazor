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
    public class DetailsModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public DetailsModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public AssistenciasPRM AssistenciasPRM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AssistenciasPRM = await _context.AssistenciasPRMS.FirstOrDefaultAsync(m => m.ID == id);

            if (AssistenciasPRM == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
