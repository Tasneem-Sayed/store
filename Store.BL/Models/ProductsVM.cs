using Store.DAL;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Models
{
  public  class ProductsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }

        [StringLength(45)]
        public string Description { get; set; }
        //public string StoreName { get; set; }
        public int StoreProductId { get; set; }
        public Stores Stores { get; set; }

      
       
    }
}
