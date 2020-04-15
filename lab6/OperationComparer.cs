using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class OperationComparer : IComparer<Operation>
    {
        public int Compare(Operation o1, Operation o2)
        {
            if (o1.Title.Length > o2.Title.Length)
                return 1;
            else if (o1.Title.Length < o2.Title.Length)
                return -1;
            else
                return 0;
        }
    }
}
