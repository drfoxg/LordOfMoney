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

            //
            // переделать управление меню, чтобы отображались только цифры из меню, все остальное нельзя было напечатать
            // см Console.ReadKey(Boolean), Console.KeyAvailable
            do
            {
                cki = Console.ReadKey();

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
