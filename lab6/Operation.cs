using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class Operation : IComparable<Operation>
    {
        public Operation(string title, string difficulty, double successOperations, double complicatedOperations)
        {
            Title = title;
            Difficulty = difficulty;
            SuccessOperations = successOperations;
            ComplicatedOperations = complicatedOperations;
        }

        public int CompareTo(Operation op)
        {
            if (op != null)
                return this.Title.CompareTo(op.Title);
            else
                throw new Exception("Unable to compare :(");
        }

        public string Title { get; set; }

        public string Difficulty { get; set; }

        public double SuccessOperations { get; set; }

        public double ComplicatedOperations { get; set; }
    }
}
