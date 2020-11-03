using ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private const string NotEnoughMoney = "{0} can't afford {1}";
        private const string SuccBoughtProduct = "{0} bought {1}";
        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();

        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExcMsg);
                }
                this.name = value;
            }
        }
        public decimal Money
        {
                get
            {
                    return this.money;
                }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.MoneyNegativeExcMsg);
                }
                this.money = value;
        }
    }
        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return (IReadOnlyCollection<Product>)this.bag;
            }
        }
        public string BuyProduct(Product product)
        {
            if (this.Money <product.Cost)
            {
                return string.Format(NotEnoughMoney, this.Name, product.Name);
            }
            this.Money -= product.Cost;
            this.bag.Add(product);
            return string.Format(SuccBoughtProduct, this.Name, product.Name);
        }
        public override string ToString()
        {
            string productsOutput = this.bag.Count > 0 ? String.Join(", ",this.Bag) : "Nothing bought";
            return $"{this.Name} - {productsOutput}";
        }
    }
}
