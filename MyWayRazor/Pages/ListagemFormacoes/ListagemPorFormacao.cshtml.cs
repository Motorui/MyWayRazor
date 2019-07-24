using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Formacoes;
using SmartBreadcrumbs.Attributes;

namespace MyWayRazor.Pages.ListagemFormacoes
{
    [Breadcrumb("Caducidades")]
    public class ListagemPorFormacaoModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public ListagemPorFormacaoModel(ApplicationDbContext context)
        {
            db = context;
        }

        public DateTime DataTresMeses = DateTime.UtcNow.Date.AddMonths(3);
        public IList<FormacaoColaborador> ListagemCaducidades { get; set; }
        public async Task OnGetAsync(Guid id)
        {
            ListagemCaducidades = await db.FormacoesColaboradores
            .Where(i => i.FormacaoId == id)
            .Include(f => f.Formacao)
            .Include(c => c.Colaborador).Where(c => c.Colaborador.Ativo == true)
            .Include(d=> d.Colaborador.Departamento)
            .Where(d => d.FormacaoCaducidade <= DataTresMeses).ToListAsync();
        }
    }
}