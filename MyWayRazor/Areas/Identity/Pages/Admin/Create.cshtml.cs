using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWayRazor.Areas.Identity.Models;
using MyWayRazor.Data;

namespace MyWayRazor.Areas.Identity.Pages.Admin
{
    public class CreateModel : RoleNamePageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            ILogger<CreateModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public ApplicationUserRole UserRoles { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [MaxLength(50)]
            [Display(Name = "Nome")]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Role")]
            public string Role { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            PopulateRolesDropDownList(_context);
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Name = Input.Name
                };
                var result = await _userManager.CreateAsync(user, "123456");
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, Input.Role).Wait();

                    _logger.LogInformation("User created a new account with password.");

                    TempData["StatusMessage"] = "User created a new account with password.";
                    return RedirectToPage("./Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}