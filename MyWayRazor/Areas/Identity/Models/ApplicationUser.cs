using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MyWayRazor.Areas.Identity.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
