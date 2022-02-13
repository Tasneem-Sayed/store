using System;
using System.Collections.Generic;
using Store.DAL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BL.Models;

namespace Store.BL.Interface
{
 public   interface IStoreRep
    {
        IEnumerable<StoreVM> Get();
        StoreVM GetById(int id);
        IEnumerable<StoreVM> SearchByName(string Name);
       void Create(StoreVM model);
        void Update(StoreVM model);
        void Delete(int id);
    }
}
