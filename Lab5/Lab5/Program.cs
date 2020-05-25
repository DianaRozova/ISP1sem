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

        public override string Print() => $" {GeneralInfo.FirstName} {GeneralInfo.LastName} {GeneralInfo.MiddleName} {TypeOfSport} {vocation}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Human.NumberOfPeople);
            Human first = new Human(first: "Розова", last: "Диана", old: 20, middle: "Александровна");
            Console.WriteLine(first.Print());
            first = new Specialist("педагог", "Иванов", "Иван", "Иванович", 40, 3);
            Console.WriteLine(first.Print());
            Console.WriteLine(Human.NumberOfPeople);
            Console.ReadKey();
        }
    }
}
