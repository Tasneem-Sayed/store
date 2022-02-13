using Store.DAL;
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Store.BL.Models
{
   public class OrderVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        [Range(0,800)]
        public int Quantity { get; set; }

        public string StoreProductId { get; set; }
        public Stores Stores { get; set; }

        public string ProductId { get; set; }
        public Products products { get; set; }


    }
}
