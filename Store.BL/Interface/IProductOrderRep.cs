using Store.BL.Models;
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Interface
{
  public  interface IProductOrderRep
    {
        IEnumerable<ProductsOrder> Get();
        ProductsOrder GetById(int id);
        ProductsOrder Create(ProductsOrder model);
        ProductsOrder Edit(ProductsOrder model);
        void Delete(ProductsOrder model);
    }
}
