using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(IS4WebApp.Areas.Identity.IdentityHostingStartup))]
namespace IS4WebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
        }
    }
}