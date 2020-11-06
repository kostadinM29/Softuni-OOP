using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet :  IBirthable, IName
    {
        public Pet(string name,string birthday)
        {
            Name = name;
            Birthday = DateTime.ParseExact(birthday, "dd/mm/yyyy", null);
        }
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
    }
}
