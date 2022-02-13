using AutoMapper;
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
    public class StoreRep : IStoreRep
    {
        private readonly ApplicationDbContext db;
        public IMapper Mapper { get; }
        public StoreRep(ApplicationDbContext db, IMapper _Mapper)
        {
            this.db = db;
            Mapper = _Mapper;
        }

        

        public void Create(StoreVM model)
        {
            var data = Mapper.Map<Stores>(model);
            db.Stores.Add(data);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var DeletedObject = db.Stores.Find(id);
            db.Stores.Remove(DeletedObject);
            db.SaveChanges();
          
        }

        public IEnumerable<StoreVM> Get()
        {
            IEnumerable<StoreVM> data = GetAllStores();
            return data;
        }

        public StoreVM GetById(int id)
        {
            var data = GetStoreByID(id);
            return data;
        }

       

        public void Update(StoreVM model)
        {

            var data = Mapper.Map<Stores>(model);
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            db.Stores.Where(a => a.Id == model.Id).FirstOrDefault();
        }

        private IEnumerable<StoreVM> GetAllStores()
        {
            return db.Stores
                .Select(a => new StoreVM
                {
                    Id = a.Id,
                    Name = a.Name,
                    Location = a.Location
                });
        }
        private StoreVM GetStoreByID(int id)
        {
            return db.Stores
                .Where(a => a.Id == id)
                .Select(a => new StoreVM
                {
                    Id = a.Id,
                    Name = a.Name,
                    Location = a.Location
                })
                .FirstOrDefault();
        }

        public IEnumerable<StoreVM> SearchByName(string Name)
        {
            throw new NotImplementedException();
        }
    }
}