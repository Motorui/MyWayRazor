using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Formacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.ViewComponents
{
    public class CaducidadesViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;
        public DateTime DataTresMeses = DateTime.UtcNow.Date.AddMonths(3);

        public CaducidadesViewComponent(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listaCaducidades = await GetItemsAsync();

            return View("ViewCaducidades", listaCaducidades);
        }

        private Task<List<FormacaoColaborador>> GetItemsAsync()
        {
            return db.FormacoesColaboradores
                .Include(f => f.Formacao)
                .Include(c => c.Colaborador).Where(a=> a.Colaborador.Ativo == true)
                .Where(d => d.FormacaoCaducidade <= DataTresMeses).ToListAsync();
        }
    }
}
