using System;
using BusinessLogic;
using DataAccessLogic;
using Models;
using userinterface;

namespace userinterface
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            IFactory factory = new MenuFactory();
            IMenu page = factory.GetMenu(MenuType.MainMenu);
            while (running)
            {
                Console.Clear();
                page.Menu();
                MenuType userInput = page.UserChoice();
               if (userInput == MenuType.Exit)
               {
                   running = false;
                   Console.WriteLine("See you soon!!");
               }
               else
               {
                   page = factory.GetMenu(userInput);
               } 
            }
        }
    }
}
