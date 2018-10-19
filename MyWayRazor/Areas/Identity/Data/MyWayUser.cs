using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyWayRazor.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MyWayUser class
    public class MyWayUser : IdentityUser
    {
        [PersonalData]
        [MaxLength(), Display(Name = "Nome")]
        public string Name { get; set; }
    }
}
