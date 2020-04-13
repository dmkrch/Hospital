using System;
using System.Collections.Generic;
using System.Text;

namespace doctor
{
    class Operation
    {
        public Operation(string title, string difficulty, double successOperations, double complicatedOperations)
        {
            Title = title;
            Difficulty = difficulty;
            SuccessOperations = successOperations;
            ComplicatedOperations = complicatedOperations;
        }

        public string Title { get; set; }

        public string Difficulty { get; set; }

        public double SuccessOperations { get; set; }

        public double ComplicatedOperations { get; set; }
    }
}
