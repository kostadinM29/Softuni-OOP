using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> list = new List<IBirthable>();
            while (true)
            {

                List<string> command = Console.ReadLine().Split(' ').ToList(); // potential split error
                if (command[0] == "End")
                {
                    break;
                }

                if (command[0] == "Citizen")
                {
                   IBirthable citizen = new Citizen(command[1], int.Parse(command[2]), command[3],command[4]);
                    list.Add(citizen);
                }
                else if (command[0] == "Pet")
                {
                    IBirthable pet = new Pet(command[1], command[2]);
                    list.Add(pet);
                }
            }
            int birthdateNum = int.Parse(Console.ReadLine());

            List<DateTime> foundBirthdays = list.Where(x => x.Birthday.Year == birthdateNum).Select(x => x.Birthday).ToList();


            if (foundBirthdays.Any())
            {
                foreach (var date in foundBirthdays)
                {
                    Console.WriteLine($"{date:dd/mm/yyyy}");
                }
            }
        }
    }
}
