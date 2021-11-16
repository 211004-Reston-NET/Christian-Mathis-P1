using Models;

namespace userinterface
{
    public class SingletonCustomer

    {
        public static Customer customer = new Customer();
          public static Orders orders = new Orders();
        public static string location { get; set; }
        
}
}