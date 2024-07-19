using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Group5_SE1730_BookingManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Group5_SE1730_BookingManagement.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class UpdateProfileModel : PageModel
    {
        private readonly UserManager<Guest> _userManager;
        private readonly SignInManager<Guest> _signInManager;
        private readonly ILogger<UpdateProfileModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string? Message { get; set; }

        public UpdateProfileModel(UserManager<Guest> userManager, SignInManager<Guest> signInManager, ILogger<UpdateProfileModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string UserName { get; set; }
            [EmailAddress]
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Input = new InputModel
            {
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            user.FirstName = Input.FirstName;
            user.MiddleName = Input.MiddleName;
            user.LastName = Input.LastName;
            user.Address = Input.Address;
            user.City = Input.City;
            user.Country = Input.Country;
            user.UserName = Input.UserName;
            user.Email = Input.Email;
            user.PhoneNumber = Input.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User updated their profile.");
            return RedirectToPage();
        }
    }
}
