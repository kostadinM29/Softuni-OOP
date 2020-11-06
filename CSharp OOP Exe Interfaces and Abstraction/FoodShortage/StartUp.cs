using FoodShortage;
using FoodShortage.Interfaces;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Food

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
