using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Identity
{
    public class IdentityRepo : IIdentityRepo
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IEmailSender emailSender;

        public IdentityRepo(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
        }

        public SignInResult Result { get; set; }

        public bool ConfirmEmailSuccess { get; set; }

        public bool ForgotPasswordError { get; set; }

        public bool ResetPasswordSuccess { get; set; }

        public async Task CreateUser(AppUser user, string password, string callbackurl)
        {
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                /*var code = await userManager.GenerateEmailConfirmationTokenAsync(user);*/
                /*var callbackurl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);*/

                await emailSender.SendEmailAsync(user.Email, "Confirm your account - Identity Manager",
                    "Please confirm your account by clicking here: <a href=\"" + callbackurl + "\">link</a>");
                await signInManager.SignInAsync(user, isPersistent: false);
            }
        }

        public async Task LoginUser(string email, string password, bool RememberMe, bool lockout)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                Result = await signInManager.PasswordSignInAsync(user.AccountName, password, RememberMe, lockout);
            }
        }

        public async Task BlockAccount(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (await userManager.IsLockedOutAsync(user) == false)
                {
                    await userManager.SetLockoutEnabledAsync(user, true);
                }
            }
        }
        
        public async Task UnblockAccount(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (await userManager.IsLockedOutAsync(user) == true)
                {
                    await userManager.SetLockoutEnabledAsync(user, false);
                }
            }
        }

        public async Task LogOut()
        {
            await signInManager.SignOutAsync();
        }

        public async Task ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                ConfirmEmailSuccess = false;
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ConfirmEmailSuccess = false;
            }
            var result = await userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                ConfirmEmailSuccess = true;
            }
        }

        public async Task ForgotPassword(string email, string callbackurl)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ForgotPasswordError = true;
            }

            /*var code = await userManager.GeneratePasswordResetTokenAsync(user);
            var callbackurl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);*/

            await emailSender.SendEmailAsync(email, "Reset Password - Identity Manager",
                "Please reset your password by clicking here: <a href=\"" + callbackurl + "\">link</a>");
        }

        public async Task ResetPassword(string email, string code, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ResetPasswordSuccess = false;
            }

            var result = await userManager.ResetPasswordAsync(user, code, password);
            if (result.Succeeded)
            {
                ResetPasswordSuccess = true;
            }
        }
    }
}
