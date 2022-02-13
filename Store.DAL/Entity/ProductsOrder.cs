using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entity
{
   public class ProductsOrder
    {
        [Key]
        public int Id { get; set; }
        public int ProductsId { get; set; }
        [ForeignKey("ProductsId")]
        public Products Products { get; set; }
        public int OrderProductsId { get; set; }
        [ForeignKey("OrderProductsId")]
        public Order Order { get; set; }

        public int Quantity { get; set; }
    }
}
