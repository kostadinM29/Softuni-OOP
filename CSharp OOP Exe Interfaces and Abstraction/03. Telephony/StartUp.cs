using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    //     public interface IBrowsable : ICallable
    //     {
    //         public string BrowseSite(string website);
    //     }
    //     public interface ICallable
    //     {
    //         public string CallNumber(string number);
    //     }
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> numsToCall = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> sitesToVisit = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();


            ICallable stationaryPhone = new StationaryPhone();
            IBrowsable smartPhone = new Smartphone();

            for (int i = 0; i < numsToCall.Count; i++)
            {
                try
                {
                    if (numsToCall[i].Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.CallNumber(numsToCall[i]));
                    }
                    else
                    {
                        Console.WriteLine(smartPhone.CallNumber(numsToCall[i]));
                    }
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
            for (int x = 0; x < sitesToVisit.Count; x++)
            {
                try
                {
                    Console.WriteLine(smartPhone.BrowseSite(sitesToVisit[x]));
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
    //     public class Smartphone : ICallable, IBrowsable
    //     {
    //         public string CallNumber(string number)
    //         {
    //             if (!number.All(char.IsDigit))
    //             {
    //                 throw new ArgumentException("Invalid number!");
    //             }
    // 
    //             return $"Calling... {number}";
    //         }
    // 
    //         public string BrowseSite(string website)
    //         {
    //             if (website.Any(char.IsDigit))
    //             {
    //                 throw new ArgumentException("Invalid URL!");
    //             }
    // 
    //             return $"Browsing: {website}!";
    //         }
    //     }
    //     public class StationaryPhone : ICallable
    //     {
    //         public string CallNumber(string number)
    //         {
    //             if (!number.All(char.IsDigit))
    //             {
    //                 throw new ArgumentException("Invalid number!");
    //             }
    // 
    //             return $"Dialing... {number}";
    //         }
    //   }
}