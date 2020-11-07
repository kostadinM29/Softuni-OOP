using System;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favfood) : base(name, favfood)
        {
        }
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "MEEOW";
        }
    }
}