using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Identity
{
    public interface IIdentityRepo
    {
        Task CreateUser(AppUser user, string password, string callbackurl);

        Task LoginUser(string email, string password, bool RememberMe, bool lockout);

        Task BlockAccount(string id);

        Task UnblockAccount(string id);

        Task LogOut();

        Task ConfirmEmail(string userId, string code);

        Task ForgotPassword(string email, string callbackurl);

        Task ResetPassword(string email, string code, string password);

        public SignInResult Result { get; set; }

        public bool ConfirmEmailSuccess { get; set; }

        public bool ForgotPasswordError { get; set; }

        public bool ResetPasswordSuccess { get; set; }
    }
}
