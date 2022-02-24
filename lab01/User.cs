using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{

    public class User
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Otches { get; set; }

        public string Zalik { get; set; }

        public override string ToString()
        {
            return "ID: " + Zalik + "   Name: " + Surname + " " + Name + " " + Otches;
        }

        public User(string name, string surname, string otches, string zalik)
        {
            Name = name;
            Surname = surname;
            Otches = otches;
            Zalik = zalik;
        }
    }

}
