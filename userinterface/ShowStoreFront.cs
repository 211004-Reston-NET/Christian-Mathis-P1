using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace userinterface
{
    public class ShowStoreFronts : IMenu
    {
        private IStoreFrontBL _storeFront;
        public ShowStoreFronts(IStoreFrontBL p_storeFront)
        {
            _storeFront = p_storeFront;
        }
        public void Menu()
        {
            Console.WriteLine("StoreFront Locations");
            Console.WriteLine("-------------------------");
            List<StoreFront> listOfStores = _storeFront.GetStoreFrontList();
            for (var i = 0; i < listOfStores.Count; i++)
            {
                Console.WriteLine(listOfStores[i]);
                Console.WriteLine("-------------------------");
            }
            Console.WriteLine("[1] - StoreFront Columbia");
            Console.WriteLine("[2] - StoreFront Charleston");
            Console.WriteLine("[0] - Go back");
        }

        public MenuType UserChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    SingletonCustomer.location = "StoreFront Columbia";
                    SingletonCustomer.orders.Address = "872 National Guard Rd,Columbia, SC 29207";
                    SingletonCustomer.orders.StoreFrontId = 1;
                    return MenuType.ShowLineItems;
                case "2":
                    SingletonCustomer.location = "StoreFront Charleston";
                    SingletonCustomer.orders.Address = "135 Garland Way, SC 29451";
                    SingletonCustomer.orders.StoreFrontId = 2;
                    return MenuType.ShowLineItems;
                case "0":
                    return MenuType.MainMenu;

                    case "4":
                    return MenuType.Exit;
                default:
                    Console.WriteLine("Please input a valid response!"+
                                    "\nPress Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}