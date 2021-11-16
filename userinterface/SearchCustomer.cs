using System;
using System.Collections.Generic;
using System.Globalization;
using BusinessLogic;
using Models;

namespace userinterface
{
    public class SearchCustomer : IMenu

    {
        private ICustomerBL _customerBL;
        public SearchCustomer(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
          public void Menu()
        {
            Console.WriteLine("Customer Search" +
                            "\n-------------------------" +
                            "\nName - " + SingletonCustomer.customer.Name +
                            "\nEmail - " + SingletonCustomer.customer.Email +
                            "\n-------------------------" +
                            "\n   [1] - Edit Name" +
                            "\n   [2] - Edit Email" +
                            "\n   [3] - Login" +
                            "\n\n   [0] - Go Back");
        }

        public MenuType UserChoice()
        {
             string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("Type in the new value for the Name");
                    SingletonCustomer.customer.Name = Console.ReadLine().Trim().ToLower(); 
                    return MenuType.SearchForCustomer;

                case "2":
                    Console.WriteLine("Type in the new value for the Email");
                    SingletonCustomer.customer.Email = Console.ReadLine().Trim().ToLower(); 
                    return MenuType.SearchForCustomer;

                case "3":
                    Customer tempCust = _customerBL.GetSingleCustomer(SingletonCustomer.customer.Name, SingletonCustomer.customer.Email);
                    if (tempCust != null)
                    {
                        SingletonCustomer.customer = tempCust;
                        Console.WriteLine($"{SingletonCustomer.customer.Name} was found in the list of customers" +
                                            "\n   Please press enter to continue.");
                        Console.ReadLine();
                        return MenuType.MainMenu;
                    }
                    Console.WriteLine($"We couldn't find {SingletonCustomer.customer.Name}, please double check you have the correct information." +
                                    "\n   Please press enter to continue.");
                    Console.ReadLine();
                    return MenuType.SearchForCustomer;

                case "0":
                    return MenuType.MainMenu;

                default:
                    Console.WriteLine("Please input a valid response!" +
                                    "\n   Pleas press enter to continue");
                    Console.ReadLine();
                    return MenuType.SearchForCustomer;
            }
        }

    }
}
