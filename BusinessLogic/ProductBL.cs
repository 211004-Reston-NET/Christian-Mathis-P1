using System.Collections.Generic;
using BusinessLogic;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class ProductsBL : IProductBL
    {
        private IRepository _repo;
        public ProductsBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public List<Products> GetProductsList(int p_store)
        {
            throw new System.NotImplementedException();
        }

        public List<Products>SearchByCategory(int p_store)
        {
            return _repo.GetProductsList(p_store);
        }

        public List<Products> SearchByCategory(string search)
        {
            throw new System.NotImplementedException();
        }
    }
}