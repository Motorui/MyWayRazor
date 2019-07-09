using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Colaboradores;
using SmartBreadcrumbs.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Colaboradores
{
    [Breadcrumb("Colaboradores")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Colaborador> Colaborador { get;set; }

        public async Task OnGetAsync()
        {
            Colaborador = await _context.Colaboradores
                .Include(c => c.Categoria)
                .Include(c => c.Contrato)
                .Include(c => c.Departamento)
                .Include(c => c.Equipa)
                .Include(c => c.Funcao)
                .Include(c => c.HorarioContratado)
                .Include(c => c.HorarioPraticado)
                .Include(c => c.Uh).ToListAsync();
        }
    }
}
