using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string CallNumber(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {number}";
        }
    }
}
