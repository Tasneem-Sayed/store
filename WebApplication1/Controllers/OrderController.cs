using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.BL.Interface;
using Store.BL.Models;
using Store.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRep order;
        private readonly IProductsRep products;
        private readonly IStoreRep storeRep;

        public OrderController(IOrderRep order,IMapper mapper,IProductsRep  products,IStoreRep storeRep)
        {
            this.order = order;
            Mapper = mapper;
            this.products = products;
            this.storeRep = storeRep;
        }

        public IMapper Mapper { get; }

        public IActionResult Index()
        {
            var data = order.Get();
            var model = Mapper.Map<IEnumerable<OrderVM>>(data);
            ViewBag.ProductsList = new SelectList(products.Get(), "Id", "Name");
           
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.StoreList = new SelectList(storeRep.Get(), "Id", "Name");
            ViewBag.ProductsList = new SelectList(products.Get(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = Mapper.Map<Order>(model);
                    order.Create(data);
                    return RedirectToAction("Index", "Products");
                }
                ViewBag.StoreList = new SelectList(storeRep.Get(), "Id", "Name");
                ViewBag.ProductsList = new SelectList(products.Get(), "Id", "Name");
                return View(model);

            }
            catch (Exception ex)
            {
                ViewBag.StoreList = new SelectList(storeRep.Get(), "Id", "Name");
                ViewBag.ProductsList = new SelectList(products.Get(), "Id", "Name");
                return View(model);
            }
        }


    }
}
