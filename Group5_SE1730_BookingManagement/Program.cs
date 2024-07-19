using Group5_SE1730_BookingManagement.Hubs;
using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;
using Group5_SE1730_BookingManagement.Repositories.Impl;
using Group5_SE1730_BookingManagement.Services;
using Group5_SE1730_BookingManagement.Services.Impl;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

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

            // Add realtime signaIr
            builder.Services.AddSignalR();

            // Add Identity security
            builder.Services.AddIdentity<Guest, IdentityRole>()
                .AddEntityFrameworkStores<Group_5_SE1730_BookingManagementContext>()
                .AddDefaultTokenProviders();



            // Config identity options
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;  // Email là duy nhất

                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = false;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

            });

            // Cấu hình cookie cho identity
            builder.Services.ConfigureApplicationCookie(options => {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = $"/login/";
                options.LogoutPath = $"/logout/";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            // Cấu hình các cách login bên thứ 3
            builder.Services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    IConfigurationSection googleAuthNSection = configuration.GetSection("Authentication:Google");

                    // Thiết lập ClientID và ClientSecret để truy cập API google
                    googleOptions.ClientId = googleAuthNSection["ClientId"];
                    googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                    // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
                    googleOptions.CallbackPath = "/login-google";
                    googleOptions.SignInScheme = IdentityConstants.ExternalScheme;
                });


            // Add mail sender service
            builder.Services.AddOptions();                                        // Kích hoạt Options
            var mailsettings = builder.Configuration.GetSection("MailSettings");  // đọc config
            builder.Services.Configure<MailSettings>(mailsettings);               // đăng ký để Inject

            builder.Services.AddTransient<IEmailSender, MailService>();        // Đăng ký dịch vụ Mail
            // Add services to the container.
            builder.Services.AddRazorPages();
            //builder.Services.AddAntiforgery(options =>
            //{
            //    options.HeaderName = "X-CSRF-TOKEN";
            //});

            // Đăng kí Service 
            builder.Services.AddTransient<IBookingService, BookingService>();
            builder.Services.AddTransient<IGuestService, GuestService>();
            builder.Services.AddTransient<IInboxService, InboxService>();
            builder.Services.AddTransient<IMessageService, MessageService>();
            builder.Services.AddTransient<ISiteSettingsService, SiteSettingsService>();
            builder.Services.AddTransient<IRoomService, RoomService>();
            builder.Services.AddTransient<IInvoiceService, InvoiceService>();
            builder.Services.AddTransient<IHomestayService, HomestayService>();
            builder.Services.AddTransient<IFAQService, FAQService>();

            // Đăng kí Repo
            builder.Services.AddTransient<IBookingRepo, BookingRepo>();
            builder.Services.AddTransient<IGuestRepo, GuestRepo>();
            builder.Services.AddTransient<IInboxRepo, InboxRepo>();
            builder.Services.AddTransient<IMessageRepo, MessageRepo>();
            builder.Services.AddTransient<ISiteSettingRepo, SiteSettingRepo>();
            builder.Services.AddTransient<IRoomRepo, RoomRepo>();
            builder.Services.AddTransient<IInvoiceRepo, InvoiceRepo>();
            builder.Services.AddTransient<IHomestayRepo, HomestayRepo>();
            builder.Services.AddTransient<IFAQRepo, FAQRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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