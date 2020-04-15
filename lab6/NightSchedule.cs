using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class NightSchedule
    {
        public NightSchedule(List<Days> days)
        {
            daysOfWork = days;
            WorkTime = "Night";
        }

        public List<Days> daysOfWork { get; set; }

        public string WorkTime { get; set; }
    }
}
