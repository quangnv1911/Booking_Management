using Group5_SE1730_BookingManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface ISiteSettingsService
    {
        Task<SiteSettings?> GetSiteSettingsAsync();
        Task<List<FAQ>> GetFAQsAsync();
        Task<SiteSettings?> GetFirstSettingAsync();
        Task<SiteSettings?> GetLastSettingAsync();
        Task ResetSetting();

        Task UpdateNewSetting(SiteSettings currentSettings);

    }
}
