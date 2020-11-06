using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IRebel> list = new List<IRebel>();
            while (true)
            {

                List<string> command = Console.ReadLine().Split(' ').ToList();
                if (command[0] == "End")
                {
                    break;
                }

                if (command.Count == 3)
                {
                    IRebel citizen = new Citizen(command[0], int.Parse(command[1]), command[2]);
                    list.Add(citizen);
                }
                else
                {
                    IRebel robot = new Robot(command[0], command[1]);
                    list.Add(robot);
                }
            }
            string fakeNum = Console.ReadLine();

            List<string> allFakeIds = list.Where(x => x.Id.EndsWith(fakeNum)).Select(x => x.Id).ToList();


            Console.WriteLine(string.Join(Environment.NewLine, allFakeIds));
        }
    }
}
