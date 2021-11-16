 using System.Collections.Generic;
using Models;
namespace DataAccessLogic
{
    public interface IRepository
    {

        /// <summary>
        /// adds a customer to our database.
        /// </summary>
        /// <param name="p_customer"> this is the Customer class that will be added to the db </param>
        /// <returns> will return the </returns>
       Customer AddCustomer(Customer p_customer);


        /// <summary>
        /// It will add a restaurant in our database
        /// </summary>
        /// <param name="p_rest">This is the restaurant we will be adding to the database</param>
        /// <returns>It will just return the restaurant we are adding</returns>
        StoreFront AddStoreFront(StoreFront p_store);


        /// <summary>
        /// updates the LineItems with the new list of LineItems to update quantities.
        /// </summary>
        /// <param name="p_lineItems"> the LineItem that will be changed, contains new quantity value. </param>
        /// <param name="p_location"> the location so we know which list of lineItems to look for. </param>
        /// <returns> returns the updated list of LineItems. </returns>
        List<LineItems> ChangeLineItemsQuantity(List<LineItems> p_lineItems, int p_location);

        /// <summary>
        /// This will return a list of Customers stored in the database
        /// </summary>
        /// <returns> will return a list of Customers</returns>
        List<Customer> GetCustomerList();
        
        /// <summary>
        ///     This will return a list of Store Fronts from the db.
        /// </summary>
        /// <returns> will return a list of StoreFronts.</returns>
        List<StoreFront> GetStoreFrontList();

        /// <summary>
        ///     This will return a list of products from the db.
        /// </summary>
        /// <param name="p_store"> the parameter being passed in will be the store name, in order to determine which stores product list to view. </param>
        /// <returns> will return a list of products. </returns>
       List<LineItems> GetLineItemsList(int p_store);

       /// <summary>
        /// This will return a list of products from the db.
        /// </summary>
        /// <param name="p_store"> the parameter being passed in will be the store name, in order to determine which stores product list to view. </param>
        /// <returns> will return a list of products. </returns>
        List<Products> GetProductsList(int p_store);

        /// <summary>
        ///     This will grab the current list of customers, then grab the current list of Orders for our selected Customer,
        ///     Then it will add our new order to the list and send back to the db.
        /// </summary>
        /// <param name="p_customer"> The customer that will be edited from the List of Customers </param>
        /// <param name="p_order"> The Order that will be added to the list of Orders on our p_customer </param>
        /// <returns> Will return the Order that was placed. </returns>
        Orders PlaceOrder(Customer p_customer, Orders p_order);

        /// <summary>
        ///     This will grab the current list of products from db.
        /// </summary>
        /// <returns> Will return a list of products </returns>
       List<Products> GetAllProducts();

        StoreFront DeleteStoreFront(StoreFront p_store);
    }
}
