using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class LineItemsBL : ILineItemsBL
    {
        private IRepository _repo;
        public LineItemsBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public LineItems AddLineItems(LineItems s_items)
        {
            throw new NotImplementedException();
        }

        public List<LineItems> ChangeLineItemsQuantity(LineItems p_lineItems, int p_location)
        {
            List<LineItems> listOfLineItems = _repo.GetLineItemsList(p_location);
            
            for (int i = 0; i < listOfLineItems.Count; i++)
            {
                if (listOfLineItems[i].Product.Name == p_lineItems.Product.Name)
                {
                    listOfLineItems[i].Quantity = p_lineItems.Quantity;
                }
            }
            _repo.ChangeLineItemsQuantity(listOfLineItems, p_location);

            return listOfLineItems;
        }

        public List<LineItems> GetAllLineItems()
        {
            throw new NotImplementedException();
        }

        public List<LineItems> GetLineItems(string p_name)
        {
            throw new NotImplementedException();
        }

        public List<LineItems> GetLineItemsList(int p_location)
        {
            return _repo.GetLineItemsList(p_location);
        }
    }
}