using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    enum Days
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    interface ISchedule
    {
        List<Days> daysOfWork { get; set; }

        bool CheckAvailibility(string day)
        {
            for (int i = 0; i < daysOfWork.Count; ++i)
            {
                if (daysOfWork[i].ToString() == day)
                    return true;
            }

            return false;
        }


        void ShowDaysOfWork()
        {
            for (int i = 0; i < daysOfWork.Count; ++i)
            {
                Console.Write(daysOfWork[i] + " ");
            }
        }
    }
}
