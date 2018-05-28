using Microsoft.AspNet.Identity;

namespace Autorepair.Others
{
    // NOTES:
    // Required NuGet packages:
    //   - Microsoft ASP.NET Identity Owin
    //   - Microsoft.Owin.Host.SystemWeb

    public class IdentityUser : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}