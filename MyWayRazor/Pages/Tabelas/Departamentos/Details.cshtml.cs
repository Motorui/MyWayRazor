using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Tabelas.Departamentos
{
    public class DetailsModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public DetailsModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Departamento Departamento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departamento = await _context.Departamentos.FirstOrDefaultAsync(m => m.DepartamentoId == id);

            if (Departamento == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
