using Store.BL.Models;
using Store.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Interface
{
 public  interface IProductsRep
    {
        IEnumerable<Products> Get();
        Products GetById(int id);
        Products Create(Products model);
        Products Edit(Products model);
        void Delete(Products model);
    }
}
