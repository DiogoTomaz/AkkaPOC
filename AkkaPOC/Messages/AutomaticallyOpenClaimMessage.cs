using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaPOC.Messages
{
    public class AutomaticallyOpenClaimMessage
    {
        public int Number { get; private set; }
        public int Year { get; private set; }

        public AutomaticallyOpenClaimMessage(int number, int year)
        {
            this.Number = number;
            this.Year = year;
        }
    }
}
