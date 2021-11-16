using System.Collections.Generic;
using Models;

namespace BusinessLogic
{
    public interface IProductBL
    {
        /// <summary>
        /// This will return a list of Products stored in the db.
        /// </summary>
        /// <param name="p_store"> the parameter passed in will be the stores location, in order to determine which product list to use.</param>
        /// <returns>It will return a list of Products.</returns>
        List<Products> GetProductsList(int p_store);
        List<Products> SearchByCategory(string search);
    }
}