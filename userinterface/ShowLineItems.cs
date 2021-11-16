using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;
using userinterface;

namespace userinterface
{
    public class ShowLineItems : IMenu
    {
        private ILineItemsBL _lineitemsBL;
        public ShowLineItems(ILineItemsBL p_lineitemsBL)
        {
            _lineitemsBL = p_lineitemsBL;
        }
        public void Menu()
        {
            Console.WriteLine("Current List of Products");
            Console.WriteLine("-------------------------");
            List<LineItems> listOfProducts = _lineitemsBL.GetLineItemsList(SingletonCustomer.orders.StoreFrontId);
            foreach (LineItems prod in listOfProducts)
            {
                Console.WriteLine(prod);
                Console.WriteLine("-------------------------");
            }
            Console.WriteLine("[0] - Go back");
        }

        public MenuType UserChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}