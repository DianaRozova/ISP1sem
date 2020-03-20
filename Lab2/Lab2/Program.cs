using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        //Получить текущее время и дату в двух разных форматах и вывести на экран количество нулей, единиц, …,
        //девяток в их записи.
        static void Resh1()
        {
            string firstdate = DateTime.Now.ToString("dd.MM.yyyy mm:ss");
            ResultFirstZ(firstdate);
            string seconddate = DateTime.Now.ToString("MM.yyyy.dd mm:ss:ms");
            ResultFirstZ(seconddate);
        }
        static void ResultFirstZ(string date)
        {
            Console.WriteLine(date);
            for(int i = 0; i < 9; i++)
            {
                int n = 0;
                for(int j = 0; j < date.Length; j++)
                {
                    if (date[j] == ' ' || date[j] == '.' || date[j] == ':') continue;
                    else if (date[j] == Convert.ToChar(i.ToString())) n++;
                }
                Console.WriteLine("  "+ i + ": " + n);
            }
        }
        //В заданной строке поменять порядок слов на обратный(слова разделены пробелами).
        public static void Resh2()
        {
            Console.Write("Введите строку слов: ");
            string mystring = Console.ReadLine();
            int n = 0;
            for (int i = 0; i < mystring.Length; i++)
            {
                if (mystring[i] == ' ') ++n;
            }
            Console.WriteLine(n);
            string itog = "";
            if (n > 1)
            {
                string[] mass = new string[n + 1];
                for (int i = 0; i <= n; i++)
                {
                    mass[i] = " ";
                }
                int index = 0;
                for (int i = 0; i < mystring.Length; i++)
                {
                    if (mystring[i] == ' ') ++index;
                    else mass[index] += mystring[i];
                }
                for (int i = n; i > -1; i--)
                {
                    itog += mass[i];
                }
            }
            else
            {
                itog = mystring;
            }
            Console.WriteLine("Результат: " + itog);
        }


        //Реализовать эффективное перемешивание символов строки.
        static void Resh3()
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            int[] mass = new int[str.Length];
            StringBuilder s = new StringBuilder(str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                if (i == str.Length - 1)
                {
                    for(int j = 0; j < str.Length; j++)
                    {
                        for(int f = 0; f < mass.Length-2; f++)
                        {
                            if (mass[f] != j)
                            {
                                s.Append(s[j]);
                                mass[i] = j;
                                ++i;
                                j = str.Length;
                                break;
                            }
                        }
                    }
                    continue;
                }
                mass[i] = getNewSimbol(mass, str);
                s.Append(str[mass[i]]);
            }
            Console.WriteLine("Строка: " + s);
        }
        static int getNewSimbol(int[] mass, string str) 
        {
            int k = getInt(str.Length);
            while (true)
            {
                bool inStr = false;
                for (int i = 0; i < mass.Length; i++)
                {
                    if (k == mass[i])
                    {
                        inStr = true;
                        break;
                    }
                }
                if (inStr) k = getInt(str.Length);
                else break;
            }
            return k;
        }
        static int getInt(int n)
        {
            Random r = new Random();
            return r.Next(0, n);
        }

        static void Main(string[] args)
        {
            Console.Write(" Для выхода введите 0: ");
            while (Console.ReadLine() != "0")
            {
               // Resh1();
                Resh3();
                Console.Write(" Для выхода введите 0: ");
            }
        }
    }
}
