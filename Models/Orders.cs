using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
 public class Orders
 // The orders contain information about customer orders.
 {
    private List<LineItems> _lineItems = new List<LineItems>();
        private string _address;
        private decimal _totalPrice;
        [Key]
        public int OrderId { get; set; }
        public int StoreFrontId { get; set; }
        public int CustomerId { get; set; }
        public List<LineItems> LineItems
        {
            get
            {
                return _lineItems;
            }
            set
            {
                _lineItems = value;
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
        public decimal TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                _totalPrice = value;
            }
        }

         public virtual Customer Customer { get; set; }
        public virtual StoreFront StoreFront { get; set; }
        public override string ToString()
        {
            
            return $"Items: {LineItems} \nAddress: {Address} \n____________ \nPrice: {TotalPrice}";
 }   
}
}