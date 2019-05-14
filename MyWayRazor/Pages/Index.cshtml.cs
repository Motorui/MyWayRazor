using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.Analise;
using MyWayRazor.Models.ToDoList;
using SmartBreadcrumbs.Attributes;

namespace MyWayRazor.Pages
{

    [DefaultBreadcrumb("Início")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public bool IsChecked { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public DateTime Hoje = DateTime.UtcNow.Date;
        public IList<AssistenciasPRM> AssistenciasPRMs { get; set; }

        [BindProperty]
        public ToDo ToDo { get; set; }
        public IList<ToDo> ToDoList { get; set; }
        public async Task OnGetAsync()
        {
            ToDoList = await _context.ToDos.ToListAsync();
            AssistenciasPRMs = await _context.AssistenciasPRMS.Where(d => d.Data.Date == Hoje).ToListAsync();
        }

        public async Task<IActionResult> OnPostMarkDone(int id)
        {
            if (id == 0)
            {
                return Page();
            }

            var successful = await MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }

            return RedirectToPage("./Index");
        }

        public async Task<bool> MarkDoneAsync(int id)
        {
            var item = await _context.ToDos
                .Where(x => x.ToDoId == id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            item.Done = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.ToDoId == id);
        }
    }
}
