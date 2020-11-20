using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter command;

        public Engine(ICommandInterpreter command)
        {
            this.command = command;
        }

        public void Run()
        {
            while (true)
            {
                string args = Console.ReadLine();

                try
                {
                    string result = this.command.Read(args);

                    Console.WriteLine(result);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
            }
        }
    }
}