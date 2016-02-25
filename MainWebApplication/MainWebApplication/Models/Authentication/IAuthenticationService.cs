using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWebApplication.Models.Entity;

namespace MainWebApplication.Models.Authentication
{
    public interface IAuthenticationService
    {
        void Login(User user, bool rememberMe);

        void Logoff();

        string GeneratePassword(string pass, string salt);

        User CurrentUser { get; }
    }
}
