using System;

namespace LordOfMoneyConsole
{
    class LordOfMoney
    {
        static void Main(string[] args)
        {
            About about = new About();
            Menu menu = new Menu();
            Command cmd = new Command();

            ConsoleKeyInfo cki;

            about.OutputShort();
            menu.ShowMenu();
            cmd.ShowPrompt();

            do
            {
                cki = Console.ReadKey();

            } while (cki.Key != ConsoleKey.D4);
        }
    }
}
