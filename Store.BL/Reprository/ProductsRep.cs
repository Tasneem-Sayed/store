using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.BL.Interface;
using Store.BL.Models;
using Store.DAL;
using Store.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Reprository
{
  public  class ProductsRep:IProductsRep
    {
        private readonly ApplicationDbContext db;

        public ProductsRep(ApplicationDbContext db,IMapper map)
        {
            this.db = db;
            Map = map;
        }

        public IMapper Map { get; }

        public Products Create(Products model)
        {
         
            db.Products.Add(model);
            db.SaveChanges();
            return db.Products.OrderBy(a => a.Id).LastOrDefault();

            
        }

        public void Delete(Products model)
        {
            
            db.Products.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<Products> Get()
        {
             IEnumerable<Products> data = GetProducts();
         
            return data;
        }

        public Products GetById(int id)
        {
            var data = db.Products.Where(a => a.Id == id).Include("ProductOrder").FirstOrDefault();
            return data;
        }

        public Products Edit(Products model)
        {
            
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();

        return db.Products.Find(model.Id);
        }

      //  ============================= Refactor ============================
        private IEnumerable<Products> GetProducts()
        {
            return db.Products.Include("Stores").Select(a => a);
        }
        private ProductsVM GetProductsByID(int id)
        {
            return db.Products.Where(a => a.Id == id)
                .Select(a => new ProductsVM
                {
                    Id = a.Id,
                    Name = a.Name,
                    Quantity = a.Quantity,
                    Date = a.Date,
                    Description = a.Description,
                    Price = a.Price,
                    StoreProductId=a.Stores.Id,
                    
                })
                .FirstOrDefault();
        }
        //    private IEnumerable<ProductsVM> GetAllProducts()
        //{
        //    return db.Products
        //               .Select(a => new ProductsVM
        //               {
        //                   Id = a.Id,
        //                   Name = a.Name,
        //                   Quantity = a.Quantity,
        //                   Date = a.Date,
        //                   Price=a.Price,
        //                   Description = a.Description,
        //                   Stores = a.Stores.Name

        //               });
        //}
    }
}
