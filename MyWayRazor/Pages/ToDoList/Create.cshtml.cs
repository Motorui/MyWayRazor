using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWayRazor.Models.ToDoList;

namespace MyWayRazor.Pages.ToDoList
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
            return Page();
        }

        [BindProperty]
        public ToDo ToDo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ToDo.ToDoTittle = Request.Form["ToDo.ToDoTittle"].ToString().ToUpper();
            ToDo.ToDoText = Request.Form["ToDo.ToDoText"].ToString();
            ToDo.CreatedAt = DateTime.UtcNow.Date;
            ToDo.CreatedBy = User.Identity.Name.ToString();
            ToDo.LastUpdatedAt = null;
            ToDo.LastUpdatedBy = null;
            _context.ToDos.Add(ToDo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}