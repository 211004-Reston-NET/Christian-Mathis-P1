using System.Collections.Generic;
using DataAccessLogic;
using Models;
using System.Linq;

public class RepositoryCloud : IRepository
{
     private DatabaseContext _context;
    public RepositoryCloud(DatabaseContext p_context)
    {
        _context = p_context;
    }

    public Customer AddCustomer(Customer p_customer)
    {

        _context.Customers.Add(p_customer);

        //This method will save the changes made to the database
        _context.SaveChanges();

        return p_customer;
    }

    public StoreFront AddStoreFront(StoreFront p_store)
    {
        throw new System.NotImplementedException();
    }

    public List<LineItems> ChangeLineItemsQuantity(List<LineItems> p_lineItems, int p_location)
    {
        throw new System.NotImplementedException();
    }

    public StoreFront DeleteStoreFront(StoreFront p_store)
    {
        throw new System.NotImplementedException();
    }

    public List<Products> GetAllProducts()
    {
        throw new System.NotImplementedException();
    }

    public List<Customer> GetCustomerList()
    {
        throw new System.NotImplementedException();
    }
    public List<StoreFront> GetStoreFrontList()
    {
        return _context.Storefronts.Select(store =>
        new StoreFront()
        {
            Name = store.Name,
            Address = store.Address,
            Products = store.LineItems.Select(item =>
                new LineItems()
                {
                    Quantity = item.Quantity,
                    Product = new Models.Products()
                    {
                        Name = item.Product.Name,
                        Price = item.Product.Price,
                        Description = item.Product.Description,
                        Brand = item.Product.Brand,
                        Category = item.Product.Category,
                        ProductId = item.Product.ProductId
                    },
                    LineItemsId = item.LineItemsId
                }).ToList(),
            Orders = store.Orders.Select(order => new Models.Orders()
            {
                OrderId = order.OrderId,
                Address = order.Address,
                TotalPrice = order.TotalPrice
            }).ToList(),
            StorefrontId = store.StorefrontId
        }).ToList();
    }

    public Orders PlaceOrder(Customer p_customer,Orders p_order)
    {
        // add order to customer's list of orders
        var customer = _context.Customers
        .First<Customer>(cust => cust.CustomerId == p_customer.CustomerId);
        customer.Orders.Add(new Orders()
        {
            Address = p_order.Address,
            TotalPrice = p_order.TotalPrice,
            StoreFrontId = p_order.StoreFrontId,
            CustomerId = p_order.CustomerId,
        });
        _context.SaveChanges();
        return p_order; ;
    }

    List<Products> IRepository.GetAllProducts()
    {
        throw new System.NotImplementedException();
    }

    List<Customer> IRepository.GetCustomerList()
    {
        throw new System.NotImplementedException();
    }

    List<LineItems> IRepository.GetLineItemsList(int p_store)
    {
        return _context.Lineitems
                     .Where(li => li.StoreFrontId == p_store)
                     .Select(item => new LineItems()
                     {
                         Quantity = item.Quantity,
                         Product = new Models.Products()
                         {
                             Name = item.Product.Name,
                             Price = item.Product.Price,
                             Description = item.Product.Description,
                             Brand = item.Product.Brand,
                             Category = item.Product.Category,
                             ProductId = item.Product.ProductId
                         },
                         LineItemsId = item.LineItemsId
                     }).ToList();


    }

    List<Products> IRepository.GetProductsList(int p_store)
    {
        throw new System.NotImplementedException();
    }

}