using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Lab7
{
    class Program
    {
        class Fraction : IComparable
        {
            public int chisl = 0;
            public int znam = 1;
            int sign = 1;
            public char[] separators = { ' ', '/', '-', ':' };

            public Fraction(int up, int low) {
                chisl = up;
                znam = low;
            }

            public Fraction(string str)
            {
                string reg = @"\d+[/-:]\d+$";
                while (true)
                {
                    if (Regex.IsMatch(str, reg))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод, введите строку снова");
                        str = Console.ReadLine();
                    }
                }
                string[] arrOfString = str.Split(separators);
                chisl = Int32.Parse(arrOfString[0]);
                znam = Int32.Parse(arrOfString[1]);
                if (chisl * znam > 0)
                {
                    sign = 1;
                }
                else
                {
                    sign = -1;
                }
                PrintFractiom();
            }

            public Fraction(int value)
            {
                chisl = value;
                if (chisl > 0)
                {
                    sign = 1;
                }
                else
                {
                    sign = -1;
                }
                PrintFractiom();
            }

            public void PrintFractiom()
            {
                Console.WriteLine($"Get drob {this.chisl}/{this.znam}");
            }

            private static int getNOD(int a, int b)
            {
                while (b != 0)
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }

            public static implicit operator int(Fraction number)
            {
                return number.chisl / number.znam;
            }

            public static explicit operator double(Fraction number)
            {
                return (double)number.chisl / number.znam;
            }

            private static int getNOK(int a, int b)
            {
                return a * b / getNOD(a, b);
            }

            private static Fraction performOperation(Fraction a, Fraction b, Func<int, int, int> operation)
            {
                int NOK = getNOK(a.znam, b.znam);
                int fractionFactor1 = NOK / a.znam;
                int fractionFactor2 = NOK / b.znam;
                int result = operation(a.chisl * fractionFactor1, b.chisl * fractionFactor2);
                return new Fraction(result, a.znam * fractionFactor1);
            }

            public static Fraction operator +(Fraction a, Fraction b)
            {
                return performOperation(a, b, (int x, int y) => x + y);
            }

            public static Fraction operator +(Fraction a, int b)
            {
                return a + new Fraction(b);
            }

            public static Fraction operator -(Fraction a, Fraction b)
            {
                return performOperation(a, b, (int x, int y) => x - y);
            }

            public static Fraction operator -(Fraction a, int b)
            {
                return a - new Fraction(b);
            }

            public static Fraction operator *(Fraction a, Fraction b)
            {
                return new Fraction(a.chisl * a.sign * b.chisl * b.sign, a.znam * b.znam);
            }

            public static Fraction operator /(Fraction a, Fraction b)
            {
                return a * b.GetReverse();
            }

            public static Fraction operator /(Fraction a, int b)
            {
                return a / new Fraction(b);
            }

            public static Fraction operator ++(Fraction a)
            {
                return a + 1;
            }

            public static Fraction operator --(Fraction a)
            {
                return a - 1;
            }

            private Fraction GetReverse()
            {
                return new Fraction(this.znam * this.sign, this.chisl);
            }

            public Fraction Reduce()
            {
                Fraction result = this;
                int greatestCommonDivisor = getNOD(this.chisl, this.znam);
                result.chisl /= greatestCommonDivisor;
                result.znam /= greatestCommonDivisor;
                return result;
            }

            public override string ToString()
            {
                int[] arr = { 1, 2, 5, 10 };
                if (this.chisl == 0)
                {
                    return "0";
                }
                string result;
                if (this.sign < 0)
                {
                    result = "-";
                }
                else
                {
                    result = "";
                }
                if (this.chisl == this.znam)
                {
                    return result + "1";
                }
                if (this.znam == 1)
                {
                    return this.chisl.ToString();
                }
                int ChekDenominator = znam % 10;
                if (ChekDenominator % 10 == 0 && arr.Contains(ChekDenominator))
                {
                    double dval = this.chisl / this.znam;
                    return result + dval;
                }
                return this.chisl + "/" + this.znam;
            }

            public bool Equals(Fraction obj)
            {
                Fraction a = this.Reduce();
                Fraction b = obj.Reduce();
                return a.chisl == b.chisl &&
                a.znam == b.znam &&
                a.sign == b.sign;
            }

            public static bool operator ==(Fraction a, Fraction b)
            {
                return a.Equals(b);
            }

            public static bool operator !=(Fraction a, Fraction b)
            {
                return !(a == b);
            }

            public override int GetHashCode()
            {
                return this.sign * (this.chisl * this.chisl + this.znam * this.znam);
            }

            public int CompareTo(object obj)
            {
                if (this.Equals(obj))
                {
                    return 0;
                }
                Fraction a = this.Reduce();
                Fraction b = (Fraction)obj;
                b = b.Reduce();
                if (a.chisl * a.sign * b.znam > b.chisl * b.sign * a.znam)
                {
                    return 1;
                }
                return -1;
            }

            public static bool operator <(Fraction a, Fraction b)
            {
                return a.CompareTo(b) < 0;
            }

            public static bool operator >(Fraction a, Fraction b)
            {
                return a.CompareTo(b) > 0;
            }
        }

        static void Main(string[] args)
        {
            Fraction obj1 = new Fraction("1:2");
            Fraction obj2 = new Fraction(10);
            Fraction obj3 = new Fraction(1, 2);
            Fraction objAddition = obj1 + obj3;
            objAddition.PrintFractiom();
            Fraction objMultipe = obj1 * obj2;
            objMultipe.PrintFractiom();
            Fraction objDivision = obj1 / obj2;
            objDivision.PrintFractiom();
            Console.WriteLine(objAddition.ToString());
            Console.WriteLine(obj3.ToString());
            int chislo = obj1;
            double dchislo = (double)obj1;
            Console.WriteLine(chislo+" "+ dchislo);
            Console.ReadKey();
        }
    }
}
