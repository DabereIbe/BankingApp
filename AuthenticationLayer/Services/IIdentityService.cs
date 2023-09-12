using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationLayer.Services
{
    public interface IIdentityService
    {
        Task CreateUser(AppUser user, string password, string callbackurl);

        Task LoginUser(string email, string password, bool RememberMe, bool lockout);

        Task BlockAccount(string id);

        Task UnblockAccount(string id);

        Task LogOut();

        Task ConfirmEmail(string userId, string code);

        Task ForgotPassword(string email, string callbackurl);

        Task ResetPassword(string email, string code, string password);

        public bool Success { get; set; }

        public bool Requires2FA { get; set; }

        public bool LockedOut { get; set; }
    }
}
