﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammal
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }
        public override double WeightMultiplier => 0.10;

        public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Fruit), typeof(Vegetable) };

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
