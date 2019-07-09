using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Colaboradores;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Colaboradores
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Colaborador Colaborador { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Colaborador = await _context.Colaboradores
                .Include(c => c.Categoria)
                .Include(c => c.Contrato)
                .Include(c => c.Departamento)
                .Include(c => c.Equipa)
                .Include(c => c.Funcao)
                .Include(c => c.HorarioContratado)
                .Include(c => c.HorarioPraticado)
                .Include(c => c.Uh)
                .FirstOrDefaultAsync(m => m.ColaboradorID == id);

            if (Colaborador == null)
            {
                return NotFound();
            }
           ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
           ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoTipo");
           ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "DepartamentoNome");
           ViewData["EquipaId"] = new SelectList(_context.Equipas, "EquipaId", "EquipaNome");
           ViewData["FuncaoId"] = new SelectList(_context.Funcoes, "FuncaoId", "FuncaoNome");
           ViewData["HorarioContratadoId"] = new SelectList(_context.Horarios, "HorarioId", "HorarioId");
           ViewData["HorarioPraticadoId"] = new SelectList(_context.Horarios, "HorarioId", "HorarioId");
           ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusID", "Statuses");
           ViewData["UhId"] = new SelectList(_context.Uhs, "UhId", "IATA");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Colaborador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboradorExists(Colaborador.ColaboradorID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ColaboradorExists(int id)
        {
            return _context.Colaboradores.Any(e => e.ColaboradorID == id);
        }
    }
}
