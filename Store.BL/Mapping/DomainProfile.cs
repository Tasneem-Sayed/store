using AutoMapper;
using Store.BL.Models;
using Store.DAL;
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Mapping
{
   public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Order, OrderVM>();
            CreateMap<OrderVM, Order>();

            CreateMap<Stores, StoreVM>();
            CreateMap<StoreVM, Stores>();

            CreateMap<Products, ProductsVM>();
            CreateMap<ProductsVM, Products>();
            CreateMap<ProductsOrder, ProductOrderVM>();
            CreateMap<ProductOrderVM, ProductsOrder>();

        }
        

    }
}
