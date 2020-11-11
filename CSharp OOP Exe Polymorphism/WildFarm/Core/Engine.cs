using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Factories;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;
        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;
        public Engine()
        {
            this.animals = new List<Animal>();
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            while (true)
            {
                List<string> commandOne = Console.ReadLine().Split(' ').ToList();
                if (commandOne[0] == "End")
                {
                    break;
                }
                List<string> commandTwo = Console.ReadLine().Split(' ').ToList();


                string type = commandOne[0];
                string name = commandOne[1];
                double weight = double.Parse(commandOne[2]);
                List<string> args = commandOne.Skip(3).ToList();
                Animal animal = null;
                try
                {
                    animal = this.animalFactory.Create(type, name, weight, args);

                    this.animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                string foodType = commandTwo[0];
                int foodQuantity = int.Parse(commandTwo[1]);
                try
                {
                    Food food = this.foodFactory.CreateFood(foodType, foodQuantity);

                      animal?.Feed(food);
                   
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }
            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
