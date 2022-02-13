using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.BL.Interface;
using Store.BL.Models;
using Store.DAL.Context;
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Reprository
{
    public class ProductsOrderRep : IProductOrderRep
    {
        public ApplicationDbContext Db { get; }
        public IMapper Map { get; }
        public ProductsOrderRep(ApplicationDbContext db, IMapper map)
        {
            Db = db;
            Map = map;
        }

    

        public ProductsOrder Create(ProductsOrder model)
        {
            Db.ProductsOrder.Add(model);
            Db.SaveChanges();
            return Db.ProductsOrder.OrderBy(a => a.Id).LastOrDefault();

        }

        public void Delete(ProductsOrder model)
        {
           Db.ProductsOrder.Remove(model);
            Db.SaveChanges();
        }

        public ProductsOrder Edit(ProductsOrder model)
        {
            Db.Entry(model).State = EntityState.Modified;
            Db.SaveChanges();

            return Db.ProductsOrder.Find(model.Id);
        }

        public IEnumerable<ProductsOrder> Get()
        {

            IEnumerable<ProductsOrder> data = GetProductsOrder();

            return data;
        }

        public ProductsOrder GetById(int id)
        {
            var data = Db.ProductsOrder.Where(a => a.Id == id).Include("ProductOrder").FirstOrDefault();
            return data;
        }
    
        private IEnumerable<ProductsOrder> GetProductsOrder()
        {
            return Db.ProductsOrder.Include("Products").Include("Order").Select(a => a);
            //var result=Db.ProductsOrder
            //    .Select(a=> new ProductOrderVM)
        }
    }
}
