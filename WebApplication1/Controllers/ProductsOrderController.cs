using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Interface;
using Store.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class ProductsOrderController : Controller
    {
        public ProductsOrderController(IProductOrderRep productOrderRep,IMapper mapper)
        {
            ProductOrderRep = productOrderRep;
            Mapper = mapper;
        }

        public IProductOrderRep ProductOrderRep { get; }
        public IMapper Mapper { get; }

        public IActionResult Index()
        {
            var data = ProductOrderRep.Get();
            var model = Mapper.Map<IEnumerable<ProductOrderVM>>(data);
            return View(model);
        }
    }
}
