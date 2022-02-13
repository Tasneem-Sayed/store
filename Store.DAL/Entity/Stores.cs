using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL
{
  public class Stores
    {
       
        public int Id { get; set; }
       
        public string Name { get; set; }
       
        public string Location{ get; set; }

        public ICollection<Products> Products { get; set; }
        public ICollection<Order> Order { get; set; }
       

    }
}
