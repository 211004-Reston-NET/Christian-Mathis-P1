using System;
using System.Collections.Generic;

namespace Models
{
    public class StoreFront
    //The store front contains information about the locations of the store(s)
    {
       private string _name;
        private string _address;
        private string _location;
        private List<LineItems> _products;
        private List<Orders> _orders;  
         public List<LineItems> LineItems;



        public int StorefrontId { get; set; }

        //properties
          public string Name { 
            get
            {
                return _name;
            }
            set
            { 
                _name = value;
            } 
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        public string Location {
            get
            {
                return _location;        
            }
            set
            {
                _location = value;            
            }
        
        }
        public List<LineItems> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
            }
        }
        public List<Orders> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
            }
        }

        public override string ToString()
        {
            return $"Id: {StorefrontId} \nName: {Name} \nAddress: {Address} ";
        }
    }
}
