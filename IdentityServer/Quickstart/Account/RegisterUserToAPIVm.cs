using System;

namespace IdentityServer.Quickstart.Account
{
    public class RegisterUserToAPIVm
    {
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime RecentLoginDate { get; set; }
    }
}
