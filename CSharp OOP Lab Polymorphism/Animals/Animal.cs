using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string Name;
       private string FavoriteFood;
        public Animal(string name, string favfood)
        {
            this.Name = name;
            this.FavoriteFood = favfood;
        }
        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my favourite food is {this.FavoriteFood}";
        }
    }
}
