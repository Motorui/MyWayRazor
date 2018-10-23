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
    public class DetailsModel : PageModel
    {
        private readonly MyWayRazor.Data.MywayDbContext _context;

        public DetailsModel(MyWayRazor.Data.MywayDbContext context)
        {
            _context = context;
        }

        public Horario Horario { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Horario = await _context.Horarios.FirstOrDefaultAsync(m => m.HorarioId == id);

            if (Horario == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
