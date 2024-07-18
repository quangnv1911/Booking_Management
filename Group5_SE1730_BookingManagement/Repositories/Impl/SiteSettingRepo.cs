using Group5_SE1730_BookingManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class SiteSettingRepo : ISiteSettingRepo
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public SiteSettingRepo(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }
        public async Task<List<FAQ>> GetFAQsAsync()
        {
            return await _context.FAQs.ToListAsync();
        }

        public async Task<SiteSettings?> GetFirstSettingAsync()
        {
            return await _context.SiteSettings.FirstOrDefaultAsync();
        }

        public async Task<SiteSettings?> GetLastSettingAsync()
        {
            return await _context.SiteSettings.OrderByDescending(d => d.Id).FirstOrDefaultAsync();
        }

        public async Task<SiteSettings?> GetSiteSettingsAsync()
        {
            return await _context.SiteSettings.OrderByDescending(i => i.Id).FirstOrDefaultAsync();
        }

        public async Task ResetSetting(SiteSettings currentSettings, SiteSettings defaultSettings)
        {
           currentSettings.LogoUrl = defaultSettings.LogoUrl;
            currentSettings.AppName = defaultSettings.AppName;
            currentSettings.FaviconUrl = defaultSettings.FaviconUrl;
            currentSettings.PrivacyText = defaultSettings.PrivacyText;
            _context.SiteSettings.Update(currentSettings);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNewSetting(SiteSettings currentSettings)
        {
            _context.SiteSettings.Update(currentSettings);
            await _context.SaveChangesAsync();
        }
    }
}
