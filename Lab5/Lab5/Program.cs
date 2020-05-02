using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab5
{
    enum TypeOfSport
    {
        Badminton = 0,
        Basketball = 1,
        Baseball,
        Boxing,
        Cycling,
        Handball,
        Judo
    };
    class Human
    {
        public static int NumberOfPeople = 0;

        protected struct GeneralInfo
        {
            static string _FirstName = " ";
            static string _LastName = " ";
            static string _MiddleName;

            static internal string FirstName
            {
                get => _FirstName;
                set
                {
                    if (Regex.Match(value, "[а-яА-Я]").Success)
                    {
                        _FirstName = value;
                    }
                }
            }
            static internal string LastName
            {
                get => _LastName;
                set
                {
                    if (Regex.Match(value, "[а-яА-Я]").Success)
                    {
                        _LastName = value;
                    }
                }
            }
            static internal string MiddleName
            {
                get => _MiddleName;
                set
                {
                    if (Regex.Match(value, "[а-яА-Я]").Success)
                    {
                        _MiddleName = value;
                    }
                }
            }
        }
        protected int age = 0;

        public Human(string first, string last, string middle, int old)
        {
            GeneralInfo.FirstName = first;
            GeneralInfo.LastName = last;
            GeneralInfo.MiddleName = middle;
            age = old;
            ++NumberOfPeople;
        }

        public string this[string propname]
        {
            get
            {
                switch (propname)
                {
                    case "name": return GeneralInfo.FirstName;
                    case "lstname": return GeneralInfo.LastName;
                    default: return "не найдено";
                }
            }
            set
            {
                switch (propname)
                {
                    case "name":
                        GeneralInfo.FirstName = value;
                        break;
                    case "lstname":
                        GeneralInfo.LastName = value;
                        break;
                    default:
                        break;
                }
            }
        }
        public virtual string Print() => $" {GeneralInfo.FirstName} {GeneralInfo.LastName} {GeneralInfo.MiddleName}";
    }
    class Sportsmen : Human
    {
        public string TypeOfSport { get; set; }

        public Sportsmen(string FirstName, string LastName, string MiddleName, int age, string typeofsport)
            : base(FirstName, LastName, MiddleName, age)
        {
            (TypeOfSport) = (typeofsport);
        }
        public Sportsmen(string FirstName, string LastName, string MiddleName, int age, int typeofsport)
            : base(FirstName, LastName, MiddleName, age)
        {
            (TypeOfSport) = Enum.GetName(typeof(TypeOfSport), typeofsport);
        }

    }
    class Specialist : Sportsmen
    {
        public Specialist(string proff, string FirstName, string LastName, string MiddleName, int age, string typeofsport) :
            base(FirstName, LastName, MiddleName, age, typeofsport) => (vocation) = (proff);

        public Specialist(string proff, string FirstName, string LastName, string MiddleName, int age, int typeofsport) :
            base(FirstName, LastName, MiddleName, age, typeofsport) => (vocation) = (proff);

        public string vocation;

        public void AddToPrint(string str1)
        {
            Console.WriteLine(Print() + " " + str1);
        }
        public void AddToPrint(string str1, string str2)
        {
            Console.WriteLine(Print() + " " + str1 + " " + str2);
        }
        public void AddToPrint(params string[] args)
        {
            Console.WriteLine(Print());
            foreach (var x in args)
            {
                Console.WriteLine(x);
            }
        }
        public override string Print() => $" {GeneralInfo.FirstName} {GeneralInfo.LastName} {GeneralInfo.MiddleName} {TypeOfSport} {vocation}";
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
            Human first = new Human(first: firstName, last: lastName, old: age, middle: "");
            Console.Write("Write type of sport: ");
            string typeOfSport = Console.ReadLine();
            Console.Write("Write speciality of sport: ");
            string special = Console.ReadLine();
            Specialist second = new Specialist(special, firstName, lastName, "", age, typeOfSport);
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
