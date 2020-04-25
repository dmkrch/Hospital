using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class ScheduleMethods
    {
        public static bool CheckAvailibility(string day, ISchedule schedule)
        {
            for (int i = 0; i < schedule.daysOfWork.Count; ++i)
            {
                if (schedule.daysOfWork[i].ToString() == day)
                    return true;
            }

            return false;
        }


        public static void ShowDaysOfWork(ISchedule schedule)
        {
            for (int i = 0; i < schedule.daysOfWork.Count; ++i)
            {
                Console.Write(schedule.daysOfWork[i] + " ");
            }
        }
    }
}
