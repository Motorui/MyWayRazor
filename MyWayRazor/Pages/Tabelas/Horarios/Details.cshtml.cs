using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models.Tabelas;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Tabelas.Horarios
{
    public class DetailsModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public DetailsModel(Data.ApplicationDbContext context)
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
