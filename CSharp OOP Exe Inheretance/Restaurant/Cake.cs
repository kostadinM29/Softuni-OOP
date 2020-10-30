using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double cakeGrams = 22;
        private const double cakeCalories = 1000;
        private const decimal cakePrice = 5;
        public Cake(string name) : base(name, cakePrice, cakeGrams,cakeCalories)
        {

        }
    }
}
