using Store.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Models
{
  public  class ProductOrderVM
    {
        public int Id { get; set; }
        public int ProductsId { get; set; }
      
        public Products Products { get; set; }
        public int OrderProductsId { get; set; }
     
        public Order Order { get; set; }

        public int Quantity { get; set; }

        public string ProductName { get; set; }

    }
}
