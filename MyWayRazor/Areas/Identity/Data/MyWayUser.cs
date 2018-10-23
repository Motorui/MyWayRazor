using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyWayRazor.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MyWayUser class
    public class MyWayUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
    }
}
