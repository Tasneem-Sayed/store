
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL
{

public class Order {
       

    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public int StoreOrderId { get; set; }
    [ForeignKey("StoreOrderId")]
    public Stores Stores { get; set; }
        //public ICollection<Products> Products { get; set; }
        public ICollection<ProductsOrder> ProductsOrder { get; set; }


    }
}
