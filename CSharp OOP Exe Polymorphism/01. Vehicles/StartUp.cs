using VehiclesExtension.Core;
using VehiclesExtension.Models;
using System;
using System.Linq;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}

