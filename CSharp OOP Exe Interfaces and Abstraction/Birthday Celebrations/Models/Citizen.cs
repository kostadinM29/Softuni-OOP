using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IIdentifiable, IName, IBirthable
    {
        private int Age;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = DateTime.ParseExact(birthday, "dd/mm/yyyy", null);
        }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
    }
}
