using FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Citizen : IIdentifiable, IName, IBirthable, IAge, IBuyer
    {

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = DateTime.ParseExact(birthday, "dd/mm/yyyy", null);
        }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public int Food { get; private set; }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
