using Group5_SE1730_BookingManagement.Services;
using Group5_SE1730_BookingManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Pages.Admins
{
    public class CustomerManagementModel : PageModel
    {
        private readonly IGuestService _guestService;
        private readonly ILogger<CustomerManagementModel> _logger;

        public CustomerManagementModel(IGuestService guestService, ILogger<CustomerManagementModel> logger)
        {
            _guestService = guestService;
            _logger = logger;
        }

        public IList<Guest> Guests { get; set; }

        public void OnGet()
        {
            _logger.LogInformation("OnGet method called.");

            try
            {
                Guests = _guestService.GetGuests();
                _logger.LogInformation("Guests retrieved successfully. Count: {Count}", Guests.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving guests.");
            }
        }

        public IActionResult OnPostDelete(string id)
        {
            _logger.LogInformation("OnPostDelete method called with id: {Id}", id);

            try
            {
                _guestService.DeleteGuest(id);
                _logger.LogInformation("Guest with id {Id} deleted successfully.", id);
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting guest with id: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
