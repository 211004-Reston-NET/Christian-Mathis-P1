using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class CustomerBL : ICustomerBL
    {
        private IRepository _repo;

               /// We are defining the dependencies this class needs to operate
        /// We do it this way because we can easily switch out which implementation details we will be using
        /// But later on the lecture, we can then switch our RRDL project to point to an actual database in the cloud and we don't have to touch anything else to
        /// have the implementation
        /// </summary>
        /// <param name="p_repo">It will pass in a Respository object</param>
        public CustomerBL(IRepository p_repo)
        {
            _repo = p_repo;


        }
        public Customer AddCustomer(Customer p_customer)
        {
            return _repo.AddCustomer(p_customer);
        }
      public List<Customer> GetCustomerList()
        {
            return _repo.GetCustomerList();
        }

        public Customer GetSingleCustomer(string p_name, string p_email)
        {
            List<Customer> listOfCustomers = _repo.GetCustomerList();
            return listOfCustomers.FirstOrDefault(cust => cust.Name == p_name && cust.Email == p_email);
        }

        public Orders PlaceOrder(Customer p_customer, Orders P_order)
        {   
            return _repo.PlaceOrder(p_customer, P_order);
        }
    }
}