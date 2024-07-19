﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Group5_SE1730_BookingManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace Group5_SE1730_BookingManagement.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<Guest> _signInManager;
        private readonly UserManager<Guest> _userManager;
        private readonly IUserStore<Guest> _userStore;
        private readonly IUserEmailStore<Guest> _emailStore;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ExternalLoginModel> _logger;

        public ExternalLoginModel(
            SignInManager<Guest> signInManager,
            UserManager<Guest> userManager,
            IUserStore<Guest> userStore,
            ILogger<ExternalLoginModel> logger,
            IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _logger = logger;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ProviderDisplayName { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public IActionResult OnGet() => RedirectToPage("./login");

        public async Task<IActionResult> OnPost(string provider, string returnUrl = null)
        {
            // Kiểm tra yêu cầu dịch vụ provider tồn tại
            var listprovider = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var provider_process = listprovider.Find((m) => m.Name == provider);
            if (provider_process == null)
            {
                return NotFound("Dịch vụ không chính xác: " + provider);
            }

            // redirectUrl - là Url sẽ chuyển hướng đến - sau khi CallbackPath (/dang-nhap-tu-google) thi hành xong
            // nó bằng identity/account/externallogin?handler=Callback
            // tức là gọi OnGetCallbackAsync
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });

            // Cấu hình
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            // Chuyển hướng đến dịch vụ ngoài (Googe, Facebook)
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("${Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);
                return LocalRedirect(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ReturnUrl = returnUrl;
                ProviderDisplayName = info.ProviderDisplayName;
                if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
                {
                    Input = new InputModel
                    {
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                    };
                }
                return Page();
            }
        }

        public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            // Lấy lại Info
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Không có thông tin tài khoản ngoài.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }



            if (ModelState.IsValid)
            {

                string externalMail = null;
                if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
                {
                    externalMail = info.Principal.FindFirstValue(ClaimTypes.Email);
                }
                var userWithexternalMail = (externalMail != null) ? (await _userManager.FindByEmailAsync(externalMail)) : null;

                // Xử lý khi có thông tin về email từ info, đồng thời có user với email đó
                // trường hợp này sẽ thực hiện liên kết tài khoản ngoài + xác thực email luôn     
                if ((userWithexternalMail != null) && (Input.Email == externalMail))
                {
                    // xác nhận email luôn nếu chưa xác nhận
                    if (!userWithexternalMail.EmailConfirmed)
                    {
                        var codeactive = await _userManager.GenerateEmailConfirmationTokenAsync(userWithexternalMail);
                        await _userManager.ConfirmEmailAsync(userWithexternalMail, codeactive);
                    }
                    // Thực hiện liên kết info và user
                    var resultAdd = await _userManager.AddLoginAsync(userWithexternalMail, info);
                    if (resultAdd.Succeeded)
                    {
                        // Thực hiện login    
                        await _signInManager.SignInAsync(userWithexternalMail, isPersistent: false);
                        //return ViewComponent(MessagePage.COMPONENTNAME, new MessagePage.Message()
                        //{
                        //    title = "LIÊN KẾT TÀI KHOẢN",
                        //    urlredirect = returnUrl,
                        //    htmlcontent = $"Liên kết tài khoản {userWithexternalMail.UserName} với {info.ProviderDisplayName} thành công"
                        //});
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        //return ViewComponent(MessagePage.COMPONENTNAME, new MessagePage.Message()
                        //{
                        //    title = "LIÊN KẾT TÀI KHOẢN",
                        //    urlredirect = Url.Page("Index"),
                        //    htmlcontent = $"Liên kết thất bại"
                        //});
                        return RedirectToPage(Url.Page("Index"));
                    }
                }

                // Tài khoản chưa có, tạo tài khoản mới
                var user = new Guest { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {

                    // Liên kết tài khoản ngoài với tài khoản vừa tạo
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("Đã tạo user mới từ thông tin {Name}.", info.LoginProvider);
                        // Email tạo tài khoản và email từ info giống nhau -> xác thực email luôn
                        if (user.Email == externalMail)
                        {
                            var codeactive = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            await _userManager.ConfirmEmailAsync(user, codeactive);
                            await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);
                            //return ViewComponent(MessagePage.COMPONENTNAME, new MessagePage.Message()
                            //{
                            //    title = "TẠO VÀ LIÊN KẾT TÀI KHOẢN",
                            //    urlredirect = returnUrl,
                            //    htmlcontent = $"Đã tạo và liên kết tài khoản, kích hoạt email thành công"
                            //});
                            return LocalRedirect(returnUrl);
                        }

                        // Trường hợp này Email tạo User khác với Email từ info (hoặc info không có email)
                        // sẽ gửi email xác để người dùng xác thực rồi mới có thể đăng nhập
                        var userId = await _userManager.GetUserIdAsync(user);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = userId, code = code },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(Input.Email, "Xác nhận địa chỉ email",
                            $"Hãy xác nhận địa chỉ email bằng cách <a href='{callbackUrl}'>bấm vào đây</a>.");

                        // Chuyển đến trang thông báo cần kích hoạt tài khoản
                        if (_userManager.Options.SignIn.RequireConfirmedEmail)
                        {
                            return RedirectToPage("./RegisterConfirmation", new { Email = Input.Email });
                        }

                        // Đăng nhập ngay do không yêu cầu xác nhận email
                        await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);

                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ProviderDisplayName = info.ProviderDisplayName;
            ReturnUrl = returnUrl;
            return Page();
        }

        private Guest CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Guest>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Guest)}'. " +
                    $"Ensure that '{nameof(Guest)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the external login page in /Areas/Identity/Pages/Account/ExternalLogin.cshtml");
            }
        }

        private IUserEmailStore<Guest> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<Guest>)_userStore;
        }
    }
}
