using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Models;

namespace WebUI.Models
{
    public class StoreFrontVM
    {

        public StoreFrontVM()
        {
        
        }
        public StoreFrontVM(StoreFront p_storeFront)
        {


            this.Name = p_storeFront.Name;
            this.Address = p_storeFront.Address;
            this.StoreFrontId = p_storeFront.StorefrontId;
        }
        public string Name {
            get; set;
        }
        public string Address {
            get; set;
        }
        public int StoreFrontId {
            get; set;
        }
    }
}