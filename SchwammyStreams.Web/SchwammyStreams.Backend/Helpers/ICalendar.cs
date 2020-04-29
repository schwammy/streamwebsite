using System;
using System.Collections.Generic;
using System.Text;

namespace SchwammyStreams.Backend.Helpers
{
    public interface ICalendar
    {
        DateTime Now { get; }
    }

    public class Calendar : ICalendar
    {
        public DateTime Now 
        {
            get { return DateTime.Now; }
        }
    }
}
