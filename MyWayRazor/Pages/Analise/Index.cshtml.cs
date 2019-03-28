using System.Collections.Generic;
using System.Threading.Tasks;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;

namespace MyWayRazor.Pages.Analise
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AssistenciasPRM> AssistenciasPRM { get; set; }

        public async Task OnGetAsync()
        {
            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Início",
                Url = "~/Index",
                Order = 1
            });
            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Análise",
                Url = "/Analise",
                Order = 2
            });

            AssistenciasPRM = await _context.AssistenciasPRMS.ToListAsync();
        }
    }
}