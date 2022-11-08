using System;

namespace IdentityServer.Quickstart.Account
{
    public class UpdateRecentLoginInAPIVm
    {
        public string Email { get; set; }
        public DateTime RecentLogin { get; set; }
    }
}
