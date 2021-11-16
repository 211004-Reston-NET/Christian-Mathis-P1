using System.Collections.Generic;
using Models;

namespace BusinessLogic
{
    public interface IStoreFrontBL
    {
        /// <summary>
        /// This will return a list of StoreFronts stored in the database
        /// </summary>
        /// <returns>It will return a list of StoreFronts</returns>
        List<StoreFront> GetStoreFrontList();


        /// <summary>
        /// Adds a restaurant to the database
        /// </summary>
        /// <param name="p_rest">This is the restaurant we are adding</param>
        /// <returns>It returns the added restaurant</returns>
        StoreFront AddStoreFront(StoreFront p_store);

        StoreFront DeleteStoreFront(StoreFront p_store);
    }
}