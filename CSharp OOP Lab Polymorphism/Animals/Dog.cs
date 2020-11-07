using System;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favfood) : base(name, favfood)
        {
        }
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "DJAAF";
        }
    }
}