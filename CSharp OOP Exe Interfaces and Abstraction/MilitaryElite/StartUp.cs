using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var privates = new Dictionary<int, Private>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var cmdArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var soldierType = cmdArgs[0];
                int id;
                string firstName;
                string lastName;
                double salary;
                Corps corps;

                switch (soldierType)
                {
                    case "Private":
                        id = int.Parse(cmdArgs[1]);
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        salary = double.Parse(cmdArgs[4]);

                        var privateSoldier = new Private(id, firstName, lastName, salary);
                        privates.Add(id, privateSoldier);
                        Console.WriteLine(privateSoldier);
                        break;
                    case "LieutenantGeneral":
                        id = int.Parse(cmdArgs[1]);
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        salary = double.Parse(cmdArgs[4]);
                        var leutenantGeneral = new LeutenantGeneral(id, firstName, lastName, salary);

                        if (cmdArgs.Length >= 5)
                        {
                            for (var i = 5; i < cmdArgs.Length; i++)
                            {
                                var privateId = int.Parse(cmdArgs[i]);
                                privateSoldier = privates[privateId];

                                leutenantGeneral.Privates.Add(privateSoldier);
                            }
                        }
                        Console.WriteLine(leutenantGeneral);
                        break;
                    case "Engineer":
                        id = int.Parse(cmdArgs[1]);
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        salary = double.Parse(cmdArgs[4]);

                        if (Enum.TryParse(cmdArgs[5], out corps))
                        {
                            var engineer = new Engineer(id, firstName, lastName, salary, corps);

                            if (cmdArgs.Length >= 6)
                            {
                                for (var i = 6; i < cmdArgs.Length; i += 2)
                                {
                                    string repairPartName = cmdArgs[i];
                                    int repairHours = int.Parse(cmdArgs[i + 1]);

                                    Repair repair = new Repair(repairPartName, repairHours);
                                    engineer.Repairs.Add(repair);
                                }
                            }
                            Console.WriteLine(engineer);
                        }
                        break;
                    case "Commando":
                        id = int.Parse(cmdArgs[1]);
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        salary = double.Parse(cmdArgs[4]);

                        if (Enum.TryParse(cmdArgs[5], out corps))
                        {
                            var commando = new Commando(id, firstName, lastName, salary, corps);

                            if (cmdArgs.Length >= 6)
                            {
                                for (var i = 6; i < cmdArgs.Length; i += 2)
                                {
                                    if (Enum.TryParse(cmdArgs[i + 1], out MissionState missionState))
                                    {
                                        string missionName = cmdArgs[i];
                                        Mission mission = new Mission(missionName, missionState);
                                        commando.Missions.Add(mission);
                                    }
                                }
                                Console.WriteLine(commando);
                            }
                        }
                        break;
                    case "Spy":
                        id = int.Parse(cmdArgs[1]);
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        var codeNumber = int.Parse(cmdArgs[4]);

                        var spy = new Spy(id, firstName, lastName, codeNumber);
                        Console.WriteLine(spy);
                        break;
                    default:
                        throw new ArgumentException("Invalid Type of Soldier!");
                }
            }
        }
    }
}