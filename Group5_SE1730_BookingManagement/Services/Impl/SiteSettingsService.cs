
using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class SiteSettingsService : ISiteSettingsService
    {
        private readonly ISiteSettingRepo _siteSettingRepo;

        public SiteSettingsService(ISiteSettingRepo siteSettingRepo)
        {
            _siteSettingRepo = siteSettingRepo;
        }

        public async Task<SiteSettings> GetSiteSettingsAsync()
        {
            return await _siteSettingRepo.GetSiteSettingsAsync();
        }

        public async Task<List<FAQ>> GetFAQsAsync()
        {
            return await _siteSettingRepo.GetFAQsAsync();
        }

        public async Task<SiteSettings?> GetFirstSettingAsync()
        {
            return await _siteSettingRepo.GetFirstSettingAsync();
        }

        public async Task<SiteSettings?> GetLastSettingAsync()
        {
            return await _siteSettingRepo.GetLastSettingAsync();
        }

        public async Task ResetSetting()
        {
            var currentSettings = await _siteSettingRepo.GetLastSettingAsync();
            var defaultSettings = await _siteSettingRepo.GetFirstSettingAsync();
            await _siteSettingRepo.ResetSetting(currentSettings, defaultSettings);
        }

        public async Task UpdateNewSetting(SiteSettings currentSettings)
        {
            await _siteSettingRepo.UpdateNewSetting(currentSettings);
        }
    }
}
