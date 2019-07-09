using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWayRazor.Models.Colaboradores;
using SmartBreadcrumbs.Attributes;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Colaboradores
{
    [Breadcrumb("Novo Colaborador", FromPage = typeof(IndexModel))]
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public CreateModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", 1);
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoTipo", 4);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "DepartamentoNome", 1);
            ViewData["EquipaId"] = new SelectList(_context.Equipas, "EquipaId", "EquipaNome", 1);
            ViewData["FuncaoId"] = new SelectList(_context.Funcoes, "FuncaoId", "FuncaoNome", 5);
            ViewData["HorarioContratadoId"] = new SelectList(_context.Horarios, "HorarioId", "HorarioHora", 1);
            ViewData["HorarioPraticadoId"] = new SelectList(_context.Horarios, "HorarioId", "HorarioHora", 1);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusID", "Statuses", 2);
            ViewData["UhId"] = new SelectList(_context.Uhs, "UhId", "IATA", 1);
            return Page();
        }

        [BindProperty]
        public Colaborador Colaborador { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Colaboradores.Add(Colaborador);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}