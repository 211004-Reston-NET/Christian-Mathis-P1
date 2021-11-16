using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace DataAccessLogic
{
    public class Repository
    {
    private const string _filepath = "./../DataAccessLogic/Database/";
    private string _jsonString;
    public List<Customer> GetAllCustomers()
    {
        _jsonString = File.ReadAllText(_filepath + "Customer.json");
        return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
    }
    public Customer AddCustomer(Customer p_customer)
    {
        List<Customer> allCustomers = GetAllCustomers();
        allCustomers.Add(p_customer);
        _jsonString = JsonSerializer.Serialize(allCustomers,new JsonSerializerOptions{WriteIndented = true});
        File.WriteAllText(_filepath + "Customer.json",_jsonString);
        return p_customer;
    }
      public List<Customer> GetCustomerList()
        {
            _jsonString = File.ReadAllText(_filepath+"Customer.json");
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }

        public List<LineItems> GetLineItemsList(string p_store)
        {
            switch (p_store)
            {
                case "Columbia":
                    _jsonString = File.ReadAllText(_filepath+"Locations.json");
                    break;
                case "Charleston":
                    _jsonString = File.ReadAllText(_filepath+"Locations.json");
                    break;
                default:
                    _jsonString = File.ReadAllText(_filepath+"Locations.json");
                break;
            }
            
            return JsonSerializer.Deserialize<List<LineItems>>(_jsonString);
        }

        public List<StoreFront> GetStoreFrontList()
        {
            throw new NotImplementedException();
        }

        public Orders PlaceOrder(Customer p_customer, Orders p_order)
        {
            throw new NotImplementedException();
        }

        public List<Products> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<Products> GetProductsList(string p_store)
        {
           _jsonString = File.ReadAllText(_filepath+"Products.json");
            return JsonSerializer.Deserialize<List<Products>>(_jsonString);
        }

        public List<LineItems> ChangeLineItemsQuantity(List<LineItems> p_lineItems, string p_location)
        {
            throw new NotImplementedException();
        }
    }
}

