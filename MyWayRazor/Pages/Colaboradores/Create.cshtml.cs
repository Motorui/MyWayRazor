using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWayRazor.Data;
using MyWayRazor.Models;

namespace MyWayRazor.Pages.Colaboradores
{
    public class CreateModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public CreateModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
        ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoTipo");
        ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "DepartamentoNome");
        ViewData["EquipaId"] = new SelectList(_context.Equipas, "EquipaId", "EquipaNome");
        ViewData["FuncaoId"] = new SelectList(_context.Funcoes, "FuncaoId", "FuncaoNome");
        ViewData["HorarioContratadoId"] = new SelectList(_context.Horarios, "HorarioId", "HorarioHora");
        ViewData["HorarioPraticadoId"] = new SelectList(_context.Horarios, "HorarioId", "HorarioHora");
        ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusID", "Statuses");
        ViewData["UhId"] = new SelectList(_context.Uhs, "UhId", "IATA");
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