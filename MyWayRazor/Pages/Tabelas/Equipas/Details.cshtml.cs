using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models.Tabelas;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Tabelas.Equipas
{
    public class DetailsModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public DetailsModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Equipa Equipa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipa = await _context.Equipas.FirstOrDefaultAsync(m => m.EquipaId == id);

            if (Equipa == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
