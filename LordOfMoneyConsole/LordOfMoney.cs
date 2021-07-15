using System;
using System.Text;

namespace LordOfMoneyConsole
{
    class LordOfMoney
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine(Console.OutputEncoding.HeaderName);

            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine(Console.OutputEncoding.HeaderName);
            */


            About about = new About();
            Menu menu = new Menu();
            Command cmd = new Command();

            ConsoleKeyInfo cki;

            SalaryBalance sb;            

            about.OutputShort();
            menu.ShowMenu();
            cmd.ShowPrompt();

            //
            // переделать управление меню, чтобы отображались только цифры из меню, все остальное нельзя было напечатать
            // см Console.ReadKey(Boolean), Console.KeyAvailable
            do
            {
                cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.D1 | cki.Key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine("");
                    
                    Console.Write("Введите остаток баланса на текущий месяц: ");
                    
                    decimal sum = Convert.ToDecimal(Console.ReadLine());
                    sb = new SalaryBalance(sum);
                    
                    sb.PrintTable();
                    menu.ShowMenu();
                    cmd.ShowPrompt();
                }

                if (cki.Key == ConsoleKey.D3 | cki.Key == ConsoleKey.NumPad3)
                {
                    Console.WriteLine("");
                    about.OutputLong();
                    menu.ShowMenu();
                    cmd.ShowPrompt();
                }

            } while (cki.Key != ConsoleKey.D4 & cki.Key != ConsoleKey.NumPad4);
        }
    }
}
