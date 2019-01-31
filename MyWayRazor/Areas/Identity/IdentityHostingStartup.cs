using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MyWayRazor.Areas.Identity.IdentityHostingStartup))]
namespace MyWayRazor.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            
        }
    }
}