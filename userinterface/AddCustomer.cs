using System;
using System.Globalization;
using BusinessLogic;

namespace userinterface
{
    public class AddCustomer : IMenu
    {
        private CustomerBL _customerBL;
        public AddCustomer(CustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }

        public void Menu()
        {
            Console.WriteLine($"Name-{SingletonCustomer.customer.Name}");
            Console.WriteLine($"Address-{SingletonCustomer.customer.Address}");
            Console.WriteLine($"Email-{SingletonCustomer.customer.Email}");
            Console.WriteLine($"PhoneNumber-{SingletonCustomer.customer.PhoneNumber}");
            Console.WriteLine("Create New User");
            Console.WriteLine("[1]:Edit Name");
            Console.WriteLine("[2]:Edit Address");
            Console.WriteLine("[3]:Edit Email");
            Console.WriteLine("[4]:Edit Phone Number");
            Console.WriteLine("[5]:Save Customer");

            Console.WriteLine("[6]:Exit");
        }

        public MenuType UserChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                Console.WriteLine("Change Name");
                SingletonCustomer.customer.Name = Console.ReadLine();
                    return MenuType.AddCustomer;
                       case "2":
                Console.WriteLine("Change Address");
                SingletonCustomer.customer.Address = Console.ReadLine();
                    return MenuType.AddCustomer;
                       case "3":
                Console.WriteLine("Change Email");
                SingletonCustomer.customer.Email = Console.ReadLine();
                    return MenuType.AddCustomer;
                       case "4":
                Console.WriteLine("Change PhoneNumber");
                SingletonCustomer.customer.PhoneNumber = Console.ReadLine();
                    return MenuType.AddCustomer;
                      case "5":
                      try{
                        _customerBL.AddCustomer(SingletonCustomer.customer);
                      }
                      catch (SystemException ex)
                      {
                          Console.WriteLine(ex);
                                                                 Console.WriteLine("You must input value to all fields above"+
                                        "\nPress Enter to continue");
                        Console.ReadLine();
                        return MenuType.AddCustomer;
                      }
                    return MenuType.MainMenu;
                case "6":
                    return MenuType.Exit;
                default:
                    Console.WriteLine("   Please select one of the options from the list provided. " +
                     "\n   Please press enter to Continue");
                    Console.ReadLine();
                    return MenuType.AddCustomer;
            }
            
        }
    }
}
