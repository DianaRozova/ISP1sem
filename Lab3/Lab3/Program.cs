using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Human
    {
        public static int NumberOfPeople = 0;
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public int age = default(int);

        public Human(string first, string last, string middle, int old)
        {
            this.firstName = first;
            this.lastName = last;
            this.middleName = middle;
            this.age = old;
            ++NumberOfPeople;
        }
        public string this[string propname]
        {
            get
            {
                switch (propname)
                {
                    case "name": return firstName;
                    case "lstname": return lastName;
                    default: return "не найдено";
                }
            }
            set
            {
                switch (propname)
                {
                    case "name":
                        firstName = value;
                        break;
                    case "lstname":
                        lastName = value;
                        break;
                    default:
                        break;
                }
            }
        }
    }
    class Sportsmen : Human
    {
        public string TypeOfSport { get; set; }
        public Sportsmen(string FirstName, string LastName, string MiddleName, int age, string typeofsport)
            : base(FirstName, LastName, MiddleName, age)
        {
            (TypeOfSport) = (typeofsport);
        }

    }
    class Specialist : Sportsmen
    {
        public Specialist(string proff, string FirstName, string LastName, string MiddleName, int age, string typeofsport) :
            base(FirstName, LastName, MiddleName, age, typeofsport) => (vocation) = (proff);

        public string vocation;

        public void AddToPrint(string str1)
        {
            Console.WriteLine(print() + " " + str1);
        }
        public void AddToPrint(string str1, string str2)
        {
            Console.WriteLine(print() + " " + str1 + " " + str2);
        }
        public string print() => $"{firstName} {middleName } {lastName}";
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(Human.NumberOfPeople);
            Console.Write("Write first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Write last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Write age: ");
            int age = Convert.ToInt16(Console.ReadLine());
            Human first = new Human(first: firstName, last: lastName, old: age, middle: null);
            Console.Write("Write type of sport: ");
            string typeOfSport = Console.ReadLine();
            Console.Write("Write speciality of sport: ");
            string special = Console.ReadLine();
            Specialist second = new Specialist(special, firstName, lastName, null, age, typeOfSport);
            Console.WriteLine(second["name"]);
            Console.Write("Write add string 1: ");
            second.AddToPrint(Console.ReadLine());
            Console.Write("Write add string 2: ");
            second.AddToPrint(Console.ReadLine(), Console.ReadLine());
            Console.WriteLine(Human.NumberOfPeople);
            Console.ReadKey();
        }
    }

}
