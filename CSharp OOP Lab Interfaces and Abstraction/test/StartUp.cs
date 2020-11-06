using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Engine engine = new Engine();
                engine.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Engine
    {
        private List<Product> products;
        private List<Person> people;

        public Engine()
        {
            this.products = new List<Product>();
            this.people = new List<Person>();
        }

        public void Run()
        {
            AddPeople();
            AddProduct();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] arg = command.Split(" ");

                string personName = arg[0];
                string productName = arg[1];

                try
                {
                    Person person = this.people.First(p => p.Name == personName);   // взима конкретните обекти от списъците 
                    Product product = this.products.First(p => p.Name == productName);

                    person.BuyProduct(product);

                    //Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (InvalidOperationException ex)    // може да се прихващат различни типове грешки
                {
                    Console.WriteLine(ex.Message);
                }
                //catch (ArgumentException ar)
                //{
                //    Console.WriteLine(ar.Message);
                //}
            }

            // Print output 
            foreach (Person item in this.people)
            {
                Console.WriteLine(item);
            }
        }


        private void AddProduct()
        {
            string[] input = Console.ReadLine().Split(";");

            for (int i = 0; i < input.Length; i++)
            {
                string[] line = input[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string productInfo = line[0];
                double price = double.Parse(line[1]);

                Product product = new Product(productInfo, price);
                this.products.Add(product);
            }
        }

        private void AddPeople()
        {
            string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] line = input[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = line[0];
                double money = double.Parse(line[1]);

                Person person = new Person(name, money);
                this.people.Add(person);
            }
        }
    }

    public class Person
    {
        private string name;
        private double money;
        private List<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }

        public Person(string name, double money) : this()
        {
            Name = name;
            Money = money;
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
                    throw new ArgumentException("Name cannot be an empty");
                }

                this.name = value;
            }
        }
        public double Money
        {
            get
            {
                return this.money;
            }
            private set

            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                   // Console.WriteLine("Money cannot be negative");
                    //return;
                }

                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag
            => this.bag.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.Money -= product.Cost;
            this.bag.Add(product);
            Console.WriteLine($"{this.Name} bought {product}");
        }

        public override string ToString()
        {
            string productsOutput = this.Bag.Count > 0 ?
                String.Join(", ", this.Bag) : "Nothing bought";
            return $"{this.Name} - {productsOutput}";
        }
    }

    public class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
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
                    throw new ArgumentException("Name cannot be an empty string.");
                }

                this.name = value;
            }
        }
        public double Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.cost = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
