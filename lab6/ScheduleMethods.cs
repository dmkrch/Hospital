using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class ScheduleMethods
    {
        public static bool CheckAvailibility(string day, List<Days> daysOfWork)
        {
            for (int i = 0; i < daysOfWork.Count; ++i)
            {
                if (daysOfWork[i].ToString() == day)
                    return true;
            }

            return false;
        }


        public static void ShowDaysOfWork(List<Days> daysOfWork)
        {
            for (int i = 0; i < daysOfWork.Count; ++i)
            {
                Console.Write(daysOfWork[i] + " ");
            }
        }
    }
}
