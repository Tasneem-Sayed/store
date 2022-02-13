
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL
{
  public class Products
    {

        
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
       
        public int Quantity { get; set; }
      
        public DateTime Date { get; set; }
     
        [StringLength(45)]
        public string Description { get; set; }
        public int StoreProductId { get; set; }
        [ForeignKey("StoreProductId")]
        public Stores Stores { get; set; }
        //public ICollection<Order> Order { get; set; }
        public ICollection<ProductsOrder> ProductsOrder { get; set; }




    }
}
