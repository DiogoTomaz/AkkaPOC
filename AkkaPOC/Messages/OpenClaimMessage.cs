using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaPOC.Messages
{
    public class OpenClaimMessage
    {
        public int Number { get; private set; }
        public int Year { get; private set; }

        public OpenClaimMessage(int number, int year)
        {
            this.Number = number;
            this.Year = year;
        }
    }
}
