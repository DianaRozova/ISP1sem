using System;
using ClassLibrary1;

namespace Lab4
{
    class Program
    {
        static void writeCode()
        {
            Console.WriteLine("Write code 0 for exit");
            Console.WriteLine("Write code 1 for info about Processes");
            Console.WriteLine("Write code 2 for info about Programs");
            Console.WriteLine("Write code 3 for info about Services");
            Console.WriteLine("Write code 4 for info about OS");
            Console.WriteLine("Write code 5 for info about Drive System");
            Console.WriteLine("Write code 6 for info about Network Adapter Configuration");
            Console.WriteLine("Write code 7 for info about Video Controller");
            Console.WriteLine("Write code 8 for info about Processor");
            Console.WriteLine("Write code 9 for info about RAM");
        }
        static void Main(string[] args)
        {
            const string codes = "0123456789";
            writeCode();
            while (true)
            {
                Console.Write("Code: ");
                string code = Console.ReadLine();
                if (codes.IndexOf(code) != -1)
                {
                    if (code == "0")
                    {
                        break;
                    }
                    switch (code)
                    {
                        case "1": ManagmentStudio.Processes(); break;
                        case "2": ManagmentStudio.Programs(); break;
                        case "3": ManagmentStudio.Services(); break;
                        case "4": ManagmentStudio.InfoOS(); break;
                        case "5": ManagmentStudio.DriveSystem(); break;
                        case "6": ManagmentStudio.NetworkAdapterConfiguration(); break;
                        case "7": ManagmentStudio.VideoController(); break;
                        case "8": ManagmentStudio.Processor(); break;
                        case "9": ManagmentStudio.RAM(); break;
                        default: Console.WriteLine("Error don'n faind code"); break;
                    }
                    writeCode();
                }
            }
        }
    }
}
