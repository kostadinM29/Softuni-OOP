﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Bird
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => 0.35;

        public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Meat), typeof(Vegetable), typeof(Fruit),typeof(Seeds) };

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
