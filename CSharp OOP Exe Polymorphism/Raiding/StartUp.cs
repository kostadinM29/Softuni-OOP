﻿using Raiding.Core;
using Raiding.Models;
using System;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
