using System;
namespace userinterface
{
    public class StartMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine(" The Carolina Technology Shop, " +
            "\n   We Sell gaming processors and gaming consoles." +
            "\n   Please enter the number from the list below and press enter to begin\n " +
            "\n   [1]: Create New Account" +
            "\n   [2]: Login" +
            "\n\n   [0]: Exit");
        }

        public MenuType UserChoice()
        {
             string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    return MenuType.AddCustomer;
                case "2":
                    return MenuType.SearchForCustomer;
                case "0":
                    return MenuType.Exit;
                default:
                    Console.WriteLine("   Please select one of the options from the list provided. " +
                                    "\n   Please press enter to Continue");
                    Console.ReadLine();
                    return MenuType.StartMenu;
            }
        }
    }
}