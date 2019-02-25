using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.ToDoList;

namespace MyWayRazor.Pages.ToDoList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public string Agora { get; private set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ToDo> ToDo { get; set; }

        public async Task OnGetAsync()
        {
            DateTime currentTime = DateTime.UtcNow;

            ToDo = await _context.ToDos.ToListAsync();
            Agora = currentTime.ToShortTimeString();
        }
    }
}