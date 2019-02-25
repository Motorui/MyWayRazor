using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using MyWayRazor.Models.ToDoList;

namespace MyWayRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public bool IsChecked { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDo ToDo { get; set; }
        public IList<ToDo> ToDoList { get; set; }

        public async Task OnGetAsync()
        {
            ToDoList = await _context.ToDos.ToListAsync();
        }

        public async Task<IActionResult> MarkDone(int id)
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

            return Page();
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

    //    public async Task<IActionResult> OnPostAsync()
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return Page();
    //        }

    //        ToDo.LastUpdatedAt = DateTime.UtcNow.Date;
    //        ToDo.LastUpdatedBy = User.Identity.Name.ToString();
    //        _context.Attach(ToDo).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!ToDoExists(ToDo.ToDoId))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return Page();
    //    }

    //    private bool ToDoExists(int id)
    //    {
    //        return _context.ToDos.Any(e => e.ToDoId == id);
    //    }
    }
}
