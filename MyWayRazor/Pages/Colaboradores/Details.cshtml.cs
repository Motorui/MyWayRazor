﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Models.Colaboradores;
using SmartBreadcrumbs.Attributes;
using System.Threading.Tasks;

namespace MyWayRazor.Pages.Colaboradores
{
    [Breadcrumb("Detalhes do Formando", FromPage = typeof(IndexModel))]
    public class DetailsModel : PageModel
    {
        private readonly MyWayRazor.Data.ApplicationDbContext _context;

        public DetailsModel(MyWayRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
                .Include(c => c.Uh).FirstOrDefaultAsync(m => m.ColaboradorID == id);

            if (Colaborador == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
