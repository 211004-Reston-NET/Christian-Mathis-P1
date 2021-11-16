using System.IO;
using BusinessLogic;
using DataAccessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using userinterface;

namespace userinterface
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the UI file path
            .AddJsonFile("appsetting.json")
            .Build(); //Builds our configuration

             DbContextOptions<DatabaseContext> options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(configuration.GetConnectionString("Reference2DB"))
                .Options;



            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();

                case MenuType.AddCustomer:
                    return new AddCustomer(new CustomerBL(new RepositoryCloud(new DatabaseContext(options))));
                    case MenuType.SearchForCustomer:
                    return new SearchCustomer(new CustomerBL(new RepositoryCloud(new DatabaseContext(options))));
                case MenuType.ShowCustomer:
                    return new ShowCustomers(new CustomerBL(new RepositoryCloud(new DatabaseContext(options))));
                case MenuType.PlaceOrder:
                    return new PlaceOrder(new CustomerBL(new RepositoryCloud(new DatabaseContext(options))), new LineItemsBL(new RepositoryCloud(new DatabaseContext(options))), SingletonCustomer.location);
                case MenuType.ViewStoreFronts:
                    return new ShowStoreFronts(new StoreFrontBL(new  RepositoryCloud(new DatabaseContext(options))));
                case MenuType.ShowLineItems:
                    return new ShowLineItems(new LineItemsBL(new RepositoryCloud(new DatabaseContext(options))));
                default:
                    return null;
            }
        }
    }
}