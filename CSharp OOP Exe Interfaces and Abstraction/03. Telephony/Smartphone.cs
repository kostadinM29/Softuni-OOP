using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string CallNumber(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
        }

        public string BrowseSite(string website)
        {
            if (website.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {website}!";
        }
    }
}