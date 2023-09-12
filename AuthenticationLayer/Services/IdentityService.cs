using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationLayer.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepo identity;

        public IdentityService(IIdentityRepo identity)
        {
            this.identity = identity;
        }

        public bool Success { get; set; }

        public bool Requires2FA { get; set; }

        public bool LockedOut { get; set; }


        public async Task BlockAccount(string id)
        {
            await identity.BlockAccount(id);
        }

        public async Task ConfirmEmail(string userId, string code)
        {
            await identity.ConfirmEmail(userId, code);
            if (identity.ConfirmEmailSuccess)
            {
                Success = true;
            }
            else
            {
                Success = false;
            }
        }

        public async Task CreateUser(AppUser user, string password, string callbackurl)
        {
            await identity.CreateUser(user, password, callbackurl);
        }

        public async Task ForgotPassword(string email, string callbackurl)
        {
            await identity.ForgotPassword(email, callbackurl);
            if (identity.ForgotPasswordError)
            {
                Success = false;
            }
            else
            {
                Success = true;
            }
        }

        public async Task LoginUser(string email, string password, bool RememberMe, bool lockout)
        {
            await identity.LoginUser(email, password, RememberMe, lockout);
            if (identity.Result.Succeeded)
            {
                Success = true;
            }
            if (identity.Result.RequiresTwoFactor)
            {
                Requires2FA = true;
            }
            if (identity.Result.IsLockedOut)
            {
                LockedOut = true;
            }
        }

        public async Task LogOut()
        {
            await identity.LogOut();
        }

        public async Task ResetPassword(string email, string code, string password)
        {
            await identity.ResetPassword(email, code, password);
            if (identity.ResetPasswordSuccess)
            {
                Success = true;
            }
            else
            {
                Success = false;
            }
        }

        public async Task UnblockAccount(string id)
        {
            await identity.UnblockAccount(id);
        }
    }
}
 