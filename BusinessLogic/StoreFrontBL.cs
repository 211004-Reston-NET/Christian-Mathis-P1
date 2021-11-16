using System.Collections.Generic;
using BusinessLogic;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private IRepository _repo;
        public StoreFrontBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public StoreFront AddStoreFront(StoreFront p_store)
        {
            if (p_store.Name == null || p_store.Address == null || p_store.Location == null)
            {
                //throw new exception("You must have a value in all of the properties of the restaurant class");
            }

            return _repo.AddStoreFront(p_store);
        }

        public StoreFront DeleteStoreFront(StoreFront p_store)
        {
            throw new System.NotImplementedException();
        }

        public List<StoreFront> GetStoreFrontList()
        {
            return _repo.GetStoreFrontList();
        }
    }
}