using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Admin;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Security.Permissions;

namespace CalendarEvent
{
    public class Startup : StartupBase
    {
        private readonly IConfiguration _configuration;
        private readonly AdminOptions _adminOptions;
        public Startup(IConfiguration configuration, IOptions<AdminOptions> adminOptions)
        {
            _configuration = configuration;
            _adminOptions = adminOptions.Value;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPermissionProvider, Permissions>();
            services.AddScoped<INavigationProvider, AdminMenu>();
        }
       
    }
}
