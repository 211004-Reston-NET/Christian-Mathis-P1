using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;
using userinterface;

namespace userinterface
{
    public class PlaceOrder : IMenu
    {
        private ILineItemsBL _lineItems;
        private string _store;
        private ICustomerBL _customerBL;
        public PlaceOrder(ICustomerBL p_customerBL, ILineItemsBL p_lineItems, string p_store)
        {
            _customerBL = p_customerBL;
            _lineItems = p_lineItems;
            _store = p_store;
        }
        public void Menu()
        {
            Console.WriteLine($"Current List of Products from {SingletonCustomer.location}");
            List<LineItems> listOfLineItems = _lineItems.GetLineItemsList(SingletonCustomer.orders.StoreFrontId);
            foreach (LineItems prod in listOfLineItems)
            {
                Console.WriteLine("-------------------------" +
                                $" \nBrand: {prod.Product.Brand}" +
                                $" \nName: {prod.Product.Name}" +
                                $" \nPrice: {prod.Product.Price}" +
                                $" \nStock Left: {prod.Quantity}");
            }
            Console.WriteLine("\n_________________________" +
                            "\n      Shopping Cart" +
                            "\n-------------------------");
            if (SingletonCustomer.orders.LineItems.Count == 0)
            {
                Console.WriteLine("          empty" +
                                "\n-------------------------");
            }
            foreach (LineItems item in SingletonCustomer.orders.LineItems)
            {
                Console.WriteLine($"   {item.Product.Name} " +
                                $" \n   Quantity: {item.Quantity} " +
                                $" \n   Price: {item.Product.Price}" +
                                "\n-------------------------");
            }
            Console.WriteLine($"Store Location: {SingletonCustomer.location}" +
                            $" \nTotal Price: {SingletonCustomer.orders.TotalPrice}" +
                            "\n-------------------------" +
                            "\n   [1] - Add Product to Shopping Cart" +
                            "\n   [2] - Complete Order" +
                            "\n\n   [0] - Main Menu");
        }

        public MenuType UserChoice()
        {
            List<LineItems> listOfLineItems = _lineItems.GetLineItemsList(SingletonCustomer.orders.StoreFrontId);
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("   Please Type the name of the product you would like to add.");
                    string _inputName = Console.ReadLine().Trim().ToLower();
                    foreach (LineItems prod in listOfLineItems)
                    {
                        if (_inputName == prod.Product.Name.ToLower())
                        {
                            Console.WriteLine($"   How many {_inputName} products would you like to add?");
                            int _inputQuantity = int.Parse(Console.ReadLine().Trim());
                            prod.Quantity = _inputQuantity;
                            SingletonCustomer.orders.LineItems.Add(prod);
                            SingletonCustomer.orders.TotalPrice = SingletonCustomer.orders.TotalPrice + (_inputQuantity * prod.Product.Price);
                            if (_inputQuantity <= 0)
                            {
                                Console.WriteLine($"   You must enter a quantity higher than 0" +
                                                "\n   Press Enter to continue");
                                Console.ReadLine();
                                return MenuType.PlaceOrder;
                            }
                            else if (_inputQuantity == 1)
                            {

                                 SingletonCustomer.orders.LineItems.Add(prod);
                                SingletonCustomer.orders.TotalPrice += (_inputQuantity * prod.Product.Price);
                                Console.WriteLine($"   {_inputQuantity} {_inputName} product has been added to the Shopping Cart" +
                                                "\n   Press Enter to continue");
                                Console.ReadLine();
                            }
                            else
                            {   
                                for (int i = 0; i < _inputQuantity; i++)
                                {
                                    SingletonCustomer.orders.LineItems.Add(prod);
                                }
                                SingletonCustomer.orders.TotalPrice += (_inputQuantity * prod.Product.Price);
                                Console.WriteLine(SingletonCustomer.orders);
                                Console.WriteLine($"   {_inputQuantity} {_inputName} product have been added to the Shopping Cart" +
                                                "\n   Press Enter to continue");
                                Console.ReadLine();
                            }
                        }
                    }

                    return MenuType.PlaceOrder;
                case "2":
                    //----- add Order to Database here.----\\
                    SingletonCustomer.orders.CustomerId = SingletonCustomer.customer.CustomerId;
                    _customerBL.PlaceOrder(SingletonCustomer.customer, SingletonCustomer.orders);
                    Console.WriteLine("Order was placed");
                    Console.WriteLine("Press Enter To Continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please Input A Valid Reponse");
                    Console.WriteLine("Press Enter To Continue");
                    Console.ReadLine();
                    return MenuType.PlaceOrder;
            }
        }
    }
}