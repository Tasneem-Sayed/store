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
    public class OrderRep : IOrderRep
    {
        private readonly ApplicationDbContext db;

        public OrderRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Order Create(Order model)
        {
            db.Order.Add(model);
            db.SaveChanges();
            return db.Order.OrderBy(a => a.Id).FirstOrDefault();
        }
       

        public void Delete(Order model)
        {
            db.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<Order> Get()
        {
            var data = GetOrders();
            return data;
        }

        public Order GetById(int id)
        {
            var data = db.Order.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        public Order Update(Order model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();

            return db.Order.Find(model.Id);
        }

        //  ============================= Refactor ============================
        private IEnumerable<Order> GetOrders()
        {

            return db.Order.Include("Stores").Include("Products")
                .Select(a => a);
           
        }

        
    }
}
