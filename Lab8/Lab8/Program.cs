using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Lab8
{
    enum TypeOfSport
    {
        Volleyball = 0,
        Basketball = 1,
        Athletics,
        Boxing,
        Cycling,
        Handball,
        Judo
    };

    public interface IHuman
    {
        string Print();
    }

    public interface ISport
    {
        string TypeOfSport { get; set; }
        void PrintSport();
    }

    public class Human : IHuman, IComparable<Human>
    {
        public static int NumberOfPeople = 0;
        public delegate void NumberCount(string messege);
        public static event NumberCount Notify;
        protected int age = 0;

        public struct GeneralInfo
        {
            static string _FirstName = " ";
            static string _LastName = " ";
            static string _MiddleName = " ";

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

        public Human(string first, string last, string middle, int old)
        {
            GeneralInfo.FirstName = first;
            GeneralInfo.LastName = last;
            GeneralInfo.MiddleName = middle;
            age = old;
            NumberOfPeople++;
            if (Notify != null) Notify("Создан новый пользователь #" + NumberOfPeople);
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

        public int CompareTo(Human obj)
        {
            return this.age.CompareTo(obj.age);
        }
    }

    class Sportsmen : Human, ISport
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

        public override string Print() => $" {GeneralInfo.FirstName} {GeneralInfo.LastName} {GeneralInfo.MiddleName}";

        public void PrintSport()
        {
            Console.WriteLine($"You sport type is {TypeOfSport}");
        }
    }

    class Specialist : Sportsmen
    {
        public string vocation;
        public delegate void AddToPrint(params string[] args);
        public AddToPrint _del;

        public Specialist(string proff, string FirstName, string LastName, string MiddleName, int age, string typeofsport) :
            base(FirstName, LastName, MiddleName, age, typeofsport)
        {
            (vocation) = (proff);
        }

        public Specialist(string proff, string FirstName, string LastName, string MiddleName, int age, int typeofsport) :
            base(FirstName, LastName, MiddleName, age, typeofsport) => (vocation) = (proff);

        public override string Print() => $" {GeneralInfo.FirstName} {GeneralInfo.LastName} {GeneralInfo.MiddleName} {TypeOfSport} {vocation}";
    }

    class Program
    {
        public static string AddToPrint(params string[] args)
        {
            string rez = "";
            foreach (var x in args)
            {
                rez += " " + x;
            }
            return rez;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Human.NumberOfPeople);
            Human.Notify += (string message) => { Console.WriteLine(message); };
            Human.Notify += delegate (string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            };
            Human first = new Human(first: "Розова", last: "Диана", old: 20, middle: "Александровна");
            Specialist second = new Specialist("тренер", "Иванов", "Иван", "Иванович", 40, Enum.GetName(typeof(TypeOfSport), 2));
            Human test = second;
            test.Print();
            Specialist third = (Specialist)test;
            second._del = (string[] str) => { Console.WriteLine(second.Print() + AddToPrint(str)); };
            Console.WriteLine(second["name"]);
            Console.Write("Write add string 1: ");
            second._del(Console.ReadLine());
            Console.Write("Write add string 2: ");
            second._del(Console.ReadLine(), Console.ReadLine());
            Console.WriteLine(Human.NumberOfPeople);
            Specialist newSpethialist = new Specialist("gjdfls", "jdsfkjf", "hkjfskdf", "sihdfskd", 145, 0);
            Console.WriteLine(newSpethialist.Print());
            ISport newSportsmen = newSpethialist;
            newSportsmen.PrintSport();
            Specialist newSpesh = (Specialist)newSportsmen;
            Console.WriteLine(newSpesh.Print());
            Console.WriteLine(newSpethialist.CompareTo(second));
            Console.ReadKey();
        }

    }

}