using Store.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Interface
{
  public  interface IOrderRep
    {
        IEnumerable<Order> Get();
        Order GetById(int id);

        Order Create(Order model);
        Order Update(Order model);
        void Delete(Order model);
    }
}
