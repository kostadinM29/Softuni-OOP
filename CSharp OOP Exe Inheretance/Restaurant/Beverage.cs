using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public virtual double Millilitres { get; set; }
        public Beverage(string name, decimal price,double millilitres) : base(name,price)
        {
            this.Millilitres = millilitres;
        }
    }
}
