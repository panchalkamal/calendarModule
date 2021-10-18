using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using OrchardCore.Settings;
using System;
using System.Threading.Tasks;
namespace CalendarEvent
{
    public class AdminMenu : INavigationProvider
    {
        private readonly ISiteService _siteService;
        public AdminMenu(IStringLocalizer<AdminMenu> localizer, ISiteService siteService)
        {
            T = localizer;
            _siteService = siteService;
        }

        public IStringLocalizer T;

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder
                .Add(T["Calendar"], "6", Calendar => Calendar
                  .AddClass("calendar").Id("calendar")
                  .AddClass("Active")
                  .Add(T["New Event"], layers => layers
                        .Url("/Calendar")
                        .Permission(Permissions.ManageCalendar)
                        .LocalNav()
                    ));
            return Task.CompletedTask;

        }
    }
}
