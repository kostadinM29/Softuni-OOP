using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }
        public void Run()
        {
            try
            {
                this.ParsePeopleInput();
                this.ParseProductsInput();
                while (true)
                {
                    List<string> command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (command[0] == "END")
                    {
                        break;
                    }
                    string personName = command[0];
                    string productName = command[1];

                    Person person = this.people.FirstOrDefault(p => p.Name == personName);
                    Product product = this.products.FirstOrDefault(p => p.Name == productName);
                    if (person != null && product != null)
                    {
                        string result = person.BuyProduct(product);
                        Console.WriteLine(result);
                    }
                }
                foreach (Person person in this.people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private void ParsePeopleInput()
        {
            List<string> peopleArgs = Console.ReadLine().Split(";").ToList();

            foreach (var personStr in peopleArgs)
            {
                List<string> personArgs = personStr.Split("=", StringSplitOptions.RemoveEmptyEntries).ToList();
                string personName = personArgs[0];
                decimal personMoney = decimal.Parse(personArgs[1]);

                Person person = new Person(personName, personMoney);
                this.people.Add(person);
            }
        }
        private void ParseProductsInput()
        {
            List<string> productsArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var productStr in productsArgs)
            {
                List<string> productArgs = productStr.Split("=", StringSplitOptions.RemoveEmptyEntries).ToList();
                string productName = productArgs[0];
                decimal productCost = decimal.Parse(productArgs[1]);

                Product product = new Product(productName, productCost);
                this.products.Add(product);
            }
        }
    }
}
