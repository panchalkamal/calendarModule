using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarEvent.ViewModels
{
    public class CalendarView
    {
        public List<CalendarViewModel> events { get; set; }
    }

    public class CalendarViewModel
    {
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        //public List<CalendarViewModel> lstCalendar { get; set; }
    }
}
