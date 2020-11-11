using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private List<BaseHero> baseHeroes;

        public Engine()
        {
            this.baseHeroes = new List<BaseHero>();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string heroClass = Console.ReadLine();
                string baseNamespace = "Raiding.Models";
                Type type = Type.GetType($"{baseNamespace}.{heroClass}");
                if (type == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }
                BaseHero hero = (BaseHero)Activator.CreateInstance(type, name);

                this.baseHeroes.Add(hero);
            }
            int bossPower = int.Parse(Console.ReadLine());
            int sumOfPower = 0;
            if (this.baseHeroes.Any())
            {
                foreach (BaseHero hero in baseHeroes)
                {
                    sumOfPower += hero.Power;
                    Console.WriteLine(hero.CastAbility());
                }
            }
            string finalMessage = sumOfPower >= bossPower ? "Victory!" : "Defeat...";

            Console.WriteLine(finalMessage);
        }
    }
}
