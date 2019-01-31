using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWayRazor.Data;
using System.Linq;

namespace MyWayRazor.Areas.Identity.Pages.Admin
{
    public class RoleNamePageModel : PageModel
    {
        public SelectList RoleNameSL { get; set; }

        public void PopulateRolesDropDownList(ApplicationDbContext _context,
            object selectedDepartment = null)
        {
            var rolesQuery = from d in _context.Roles
                             orderby d.Name // Sort by name.
                             select d;

            RoleNameSL = new SelectList(rolesQuery.AsNoTracking(),
                        "Name", "Name", selectedDepartment);
        }
    }
}
