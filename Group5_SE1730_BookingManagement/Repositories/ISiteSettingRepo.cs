using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface ISiteSettingRepo
    {
        Task<SiteSettings?> GetSiteSettingsAsync();
        Task<List<FAQ>> GetFAQsAsync();
        Task<SiteSettings?> GetFirstSettingAsync();
        Task<SiteSettings?> GetLastSettingAsync();
        Task ResetSetting(SiteSettings currentSettings, SiteSettings defaultSettings);

        Task UpdateNewSetting(SiteSettings currentSettings);
    }
}
