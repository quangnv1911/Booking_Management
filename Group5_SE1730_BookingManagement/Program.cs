using Group5_SE1730_BookingManagement.Hubs;
using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;
using Group5_SE1730_BookingManagement.Repositories.Impl;
using Group5_SE1730_BookingManagement.Services;
using Group5_SE1730_BookingManagement.Services.Impl;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Group5_SE1730_BookingManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add database connection
            var configuration = builder.Configuration;
            builder.Services.AddDbContext<Group_5_SE1730_BookingManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Cnn")));

            // Add realtime SignalR
            builder.Services.AddSignalR();

            // Add Identity security
            builder.Services.AddIdentity<Guest, IdentityRole>()
                .AddEntityFrameworkStores<Group_5_SE1730_BookingManagementContext>()
                .AddDefaultTokenProviders();

            // Configure identity options
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Configure password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;

                // Configure lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;


                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;  // Email là duy nhất

                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = false;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

                // Configure user settings
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;


                // Configure sign-in settings
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            // Configure cookie settings for identity
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = $"/login/";
                options.LogoutPath = $"/logout/";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            // Configure third-party login options
            builder.Services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    IConfigurationSection googleAuthNSection = configuration.GetSection("Authentication:Google");
                    googleOptions.ClientId = googleAuthNSection["ClientId"];
                    googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                    googleOptions.CallbackPath = "/login-google";
                    googleOptions.SignInScheme = IdentityConstants.ExternalScheme;
                });

            // Add mail sender service
            builder.Services.AddOptions();
            var mailsettings = builder.Configuration.GetSection("MailSettings");
            builder.Services.Configure<MailSettings>(mailsettings);
            builder.Services.AddTransient<IEmailSender, MailService>();

            // Add services to the container
            builder.Services.AddRazorPages();


            //builder.Services.AddAntiforgery(options =>
            //{
            //    options.HeaderName = "X-CSRF-TOKEN";
            //});


            // Đăng kí Service 
            builder.Services.AddTransient<IHomestayService, HomestayService>();

            // Register services

            builder.Services.AddTransient<IBookingService, BookingService>();
            builder.Services.AddTransient<IGuestService, GuestService>();
            builder.Services.AddTransient<IInboxService, InboxService>();
            builder.Services.AddTransient<IMessageService, MessageService>();

            builder.Services.AddTransient<ISiteSettingsService, SiteSettingsService>();
            builder.Services.AddTransient<IRoomService, RoomService>();
            builder.Services.AddTransient<IInvoiceService, InvoiceService>();
            builder.Services.AddTransient<IHomestayService, HomestayService>();
            builder.Services.AddTransient<IFAQService, FAQService>();


            // Register repositories
            builder.Services.AddTransient<IBookingRepo, BookingRepo>();
            builder.Services.AddTransient<IGuestRepo, GuestRepo>();
            builder.Services.AddTransient<IInboxRepo, InboxRepo>();
            builder.Services.AddTransient<IMessageRepo, MessageRepo>();


            builder.Services.AddTransient<ISiteSettingRepo, SiteSettingRepo>();
            builder.Services.AddTransient<IRoomRepo, RoomRepo>();
            builder.Services.AddTransient<IInvoiceRepo, InvoiceRepo>();
            builder.Services.AddTransient<IHomestayRepo, HomestayRepo>();
            builder.Services.AddTransient<IFAQRepo, FAQRepo>();

            builder.Logging.AddConsole();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapHub<ChatHub>("/chatHub");

            app.Run();
        }
    }
}
