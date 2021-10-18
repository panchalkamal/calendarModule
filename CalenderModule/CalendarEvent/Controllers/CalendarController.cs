using CalendarEvent.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using System.Threading.Tasks;
using YesSql;
using OrchardCore.ContentManagement.Records;
using System.Collections.Generic;
using System;

namespace CalendarEvent
{
    public class CalendarController : Controller
    {
        private readonly IContentManager _contentManager;
        private readonly YesSql.ISession _session;
        public CalendarController(IContentManager contentManager, YesSql.ISession session)
        {
            _contentManager = contentManager;
            _session = session;
        }
        [Route("Calendar")]
        public async Task<IActionResult> Index()
        {

            CalendarView model = new CalendarView();
            var calendarItems = await _session.Query<ContentItem, ContentItemIndex>().Where(o => o.ContentType == "Calendar" && o.Latest).ListAsync();
            if (calendarItems != null)
            {
                model.events = new List<CalendarViewModel>();
                foreach (var item in calendarItems)
                {
                    CalendarViewModel detail = new CalendarViewModel();
                    detail.start = Convert.ToDateTime(item.ContentItem.Content.Calendar.StartDate.Value).ToString("yyyy-MM-dd");
                    detail.end = Convert.ToDateTime(item.ContentItem.Content.Calendar.EndDate.Value).ToString("yyyy-MM-dd");
                    detail.title = item.DisplayText;
                    model.events.Add(detail);
                }
            }
            return View(model);
        }
    }
}
