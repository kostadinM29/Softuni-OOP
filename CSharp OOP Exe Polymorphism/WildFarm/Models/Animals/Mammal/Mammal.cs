﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Mammal
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }
        public string LivingRegion { get; }
        public override string ToString()
        {

            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
