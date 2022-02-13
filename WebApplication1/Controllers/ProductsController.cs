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
    public class ProductsController : Controller
    {
        private readonly IProductsRep rep;
        private readonly IStoreRep storeRep;

        public IMapper Map { get; }

        public ProductsController(IProductsRep rep, IMapper map, IStoreRep storeRep)
        {
            this.rep = rep;
            Map = map;
            this.storeRep = storeRep;
        }
        public IActionResult Index()
        {
            var data = rep.Get();
            var model = Map.Map<IEnumerable<ProductsVM>>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.StoreList = new SelectList(storeRep.Get(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductsVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = Map.Map<Products>(model);
                    rep.Create(data);
                    return RedirectToAction("Index", "Products");
                }

                ViewBag.StoreList = new SelectList(storeRep.Get(), "Id", "Name");
                return View(model);

            }
            catch (Exception ex)
            {
                ViewBag.StoreList = new SelectList(storeRep.Get(), "Id", "Name");
                return View(model);
            }
        }

        [HttpGet]

        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = rep.GetById(id);
            var model = Map.Map<ProductsVM>(data);
            ViewBag.ProductsList = new SelectList(storeRep.Get(), "Id", "Name", model.StoreProductId);
            return View(model);
        }
      


    } 
}
